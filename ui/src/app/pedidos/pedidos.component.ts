import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { fromPedidoActions } from './store/pedidos.actions';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isCreated } from './store/pedidos.selector';
import { ComandaState } from '../comandas/store/comandas.reducers';
import {
  fromComandaActions
} from '../comandas/store/comandas.actions';
import { PedidoState } from './store/pedidos.reducers';

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
    private storePedido: Store<PedidoState>,
    private storeComandas: Store<ComandaState>,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {

    this.carregarPedidos();

    this.isCreatedCriarPedido$ = this.storePedido.select(isCreated);

    this.isCreatedCriarPedido$
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((done) => {
        this.storeComandas.dispatch(fromComandaActions.ObterComandas({ quantidade: 100 }));
        this.showMsgCriadoERedirect(done, 'Pedido criado com sucesso');
      });
  }

  carregarPedidos() {
    this.storePedido.dispatch(fromPedidoActions.ObterPedidos({ quantidade: 50 }));
  }

  showMsgCriadoERedirect(done: boolean, message: string) {
    if (done) {
      this.notificationMessageService.mostrarMensagemSucesso(message);
      this.router.navigate(['/garcons']);
    }
  }
}