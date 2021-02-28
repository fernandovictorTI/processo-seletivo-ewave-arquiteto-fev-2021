import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { isCreated } from './store/comandas.selector';
import {
  fromComandaActions
} from './store/comandas.actions';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ComandaState } from './store/comandas.reducers';

@Component({
  selector: 'app-comandas',
  template: `
    <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./comandas.component.css']
})
export class ComandasComponent implements OnInit, OnDestroy {

  private isCreatedComanda$;
  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(private router: Router,
    private store: Store<ComandaState>,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {

    this.carregarListaComandas();

    this.isCreatedComanda$ = this.store.select(isCreated);

    this.isCreatedComanda$
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((done) => {
        this.showMsgCriadoERedirect(done, 'Comanda criado com sucesso');
      });
  }

  carregarListaComandas() {
    this.store.dispatch(fromComandaActions.ObterComandas({ quantidade: 100 }));
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
      this.router.navigate(['/comandas']);
    }
  }

  showErrorAction(error, message: string) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}