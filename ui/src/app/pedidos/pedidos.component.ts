import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { AppState } from '../app.state';
import { ObterPedidos, ObterPedido } from './store/pedidos.actions';
import {
  obterPedidosError
} from './store/pedidos.reducers';

import {
  getIdDoPedidoAoAdicionarProdutoPedido
} from './store/produtospedido.reducers';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isCreated } from './store/criarpedido.selector';
import { CriarPedidoState } from './store/criarpedido.reducers';
import { ComandaState } from '../comandas/store/comandas.reducers';
import {
  fromComandaActions
} from '../comandas/store/comandas.actions';

@Component({
  selector: 'app-pedidos',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit, OnDestroy {

  private isCreatedCriarPedido$;
  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private router: Router,
    private store: Store<AppState>,
    private storeCriarPedido: Store<CriarPedidoState>,
    private storeComandas: Store<ComandaState>,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {

    this.store.dispatch(new ObterPedidos(50));

    this.store.select(obterPedidosError).subscribe((error) => this.showErroStore(error));

    this.isCreatedCriarPedido$ = this.storeCriarPedido.select(isCreated);

    this.isCreatedCriarPedido$
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((done) => {
        this.storeComandas.dispatch(fromComandaActions.ObterComandas({ quantidade: 100 }));
        this.showMsgCriadoERedirect(done, 'Pedido criado com sucesso');
      });

    this.store.select(getIdDoPedidoAoAdicionarProdutoPedido).subscribe((selected: any) => {
      if (selected)
        this.store.dispatch(new ObterPedido(selected.idPedido));
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
      this.router.navigate(['/pedidos']);
    }
  }

  showErrorAction(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}