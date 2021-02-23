import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { AppState } from '../app.state';
import { ObterPedidos, ObterPedido } from './store/pedidos.actions';
import {
  obterPedidosError
} from './store/pedidos.reducers';

import { selectCriarPedido, selectCriarPedidoError, selectCriarPedidoIsLoading } from './store/criarpedido.reducers';

import {
  getIdDoPedidoAoAdicionarProdutoPedido
} from './store/produtospedido.reducers';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { AdicionarPedidoCancelarAssinatura } from './store/criarpedido.actions';

@Component({
  selector: 'app-pedidos',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit, OnDestroy {

  constructor(
    private router: Router,
    private store: Store<AppState>,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {

    // Pedidos 
    this.store.dispatch(new ObterPedidos(50));

    // Consulta Pedidos com erro
    this.store.select(obterPedidosError).subscribe((error) => this.showErroStore(error));

    // Pedido Criado com sucesso
    this.store.select(selectCriarPedido).subscribe((cara) => {
      if(cara)
        this.showMsgCriadoERedirect('Pedido criado com sucesso');
    });

    // Erro ao criar pedido
    this.store.select(selectCriarPedidoError).subscribe((error) => {
      this.showErrorAction(error);
    });

    // Carregando novamente o pedido ao adicionar um produto
    this.store.select(getIdDoPedidoAoAdicionarProdutoPedido).subscribe((selected: any) => {
      if (selected)
        this.store.dispatch(new ObterPedido(selected.idPedido));
    });
  }

  ngOnDestroy(): void {
    this.store.dispatch(new AdicionarPedidoCancelarAssinatura());
  }

  showErroStore(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }

  showMsgCriadoERedirect(message: string) {
      this.notificationMessageService.mostrarMensagemSucesso(message);
      this.router.navigate(['/comandas']);
  }

  showErrorAction(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}