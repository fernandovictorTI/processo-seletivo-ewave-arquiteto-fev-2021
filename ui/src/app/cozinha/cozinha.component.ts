import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import {
  fromCozinhaActions
} from './store/cozinha.actions';

import { RxStompService } from '@stomp/ng2-stompjs';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { CozinhaState } from './store/cozinha.reducers';

@Component({
  selector: 'app-cozinha',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./cozinha.component.css']
})
export class CozinhaComponent implements OnInit {

  constructor(private cozinhaStore: Store<CozinhaState>,
    private rxStompService: RxStompService,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.carregarComandasAbertas();

    this.escutarAlteracoesNosPedidosDasComandas();
  }

  showErroStore(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }

  carregarComandasAbertas() {
    this.cozinhaStore.dispatch(fromCozinhaActions.ObterComandasAbertas());
  }

  escutarAlteracoesNosPedidosDasComandas() {
    this.rxStompService.watch('/queue/queue-novo-pedido').subscribe((message) => {
      this.carregarComandasAbertas();
    });
    this.rxStompService.watch('/queue/queue-inserido-produto-pedido').subscribe((message) => {
      this.carregarComandasAbertas();
    });
    this.rxStompService.watch('/queue/queue-removido-produto-pedido').subscribe((message) => {
      this.carregarComandasAbertas();
    });
    this.rxStompService.watch('/exchange/queue-situacao-pedido-alterada').subscribe((message) => {
      this.carregarComandasAbertas();
    });
  }
}
