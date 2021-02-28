import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { isCreated } from './store/produtos.selector';
import { fromProdutosActions } from './store/produtos.actions';
import {
  ProdutoState
} from './store/produtos.reducers';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-produtos',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit, OnDestroy {

  private isCreatedProduto$;
  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(private router: Router,
    private store: Store<ProdutoState>,
    private notificationMessageService: NotificationMessageService) {
  }
  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {
    this.store.dispatch(fromProdutosActions.ObterProdutos({ quantidade: 100 }));

    this.isCreatedProduto$ = this.store.select(isCreated);

    this.isCreatedProduto$
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((done) => {
        this.showMsgCriadoERedirect(done, 'Produto criado com sucesso');
      });
  }

  showErroStore(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }

  showMsgCriadoERedirect(done: boolean, message: string) {
    if (done) {
      this.notificationMessageService.mostrarMensagemSucesso(message);
      this.router.navigate(['/produtos']);
    }
  }

  showErrorAction(error, message: string) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}