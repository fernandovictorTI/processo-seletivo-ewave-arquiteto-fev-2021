import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {Router} from '@angular/router';
import {AppState} from '../app.state';
import { ObterComandasAbertas } from './store/cozinha.actions';
import {
  obterAllComandasError
} from './store/cozinha.reducers';

import { RxStompService } from '@stomp/ng2-stompjs';
import { NotificationMessageService } from '../shared/services/notification-message.service';

@Component({
  selector: 'app-cozinha',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./cozinha.component.css']
})
export class CozinhaComponent implements OnInit {

  constructor(private store: Store<AppState>,
              private rxStompService: RxStompService,
              private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.store.dispatch(new ObterComandasAbertas());

    this.escutarAlteracoesNosPedidosDasComandas();

    this.store.select(obterAllComandasError).subscribe((error) => this.showErroStore(error));
  }

  showErroStore(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }

  escutarAlteracoesNosPedidosDasComandas() {
    this.rxStompService.watch('/queue/queue-novo-pedido').subscribe((message) => {
      this.store.dispatch(new ObterComandasAbertas());
    });
    this.rxStompService.watch('/queue/queue-inserido-produto-pedido').subscribe((message) => {
      this.store.dispatch(new ObterComandasAbertas());
    });
    this.rxStompService.watch('/queue/queue-removido-produto-pedido').subscribe((message) => {
      this.store.dispatch(new ObterComandasAbertas());
    });
    this.rxStompService.watch('/exchange/queue-situacao-pedido-alterada').subscribe((message) => {
      this.store.dispatch(new ObterComandasAbertas());
    });
  }
}
