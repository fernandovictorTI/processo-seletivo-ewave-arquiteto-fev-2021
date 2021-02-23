import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {AppState} from '../../app.state';
import {Comanda} from '../shared/comanda';
import {Observable} from 'rxjs';
import {obterAllComandas} from '../store/comandas.reducers';
import { Router } from '@angular/router';
import { RxStompService } from '@stomp/ng2-stompjs';
import { ObterComandas } from '../store/comandas.actions';

@Component({
  selector: 'app-comanda-list',
  templateUrl: './comanda-list.component.html',
  styleUrls: ['./comanda-list.component.css']
})
export class ComandaListComponent implements OnInit {
  title = 'Comandas';
  comandas: Observable<Comanda[]>;

  constructor(
    private store: Store<AppState>,
    private router: Router,
    private rxStompService: RxStompService) {
  }

  ngOnInit() {
    this.comandas = this.store.select(obterAllComandas);

    this.rxStompService.watch('/queue/queue-situacao-pedido-alterada').subscribe((message) => {
      this.store.dispatch(new ObterComandas(1000));
    });
  }

  abrirComanda(idComanda) {
    this.router.navigate(['/pedidos/criar', idComanda]);
  }

  gerenciarComanda(idPedido) {
    this.router.navigate(['/pedidos/gerenciar', idPedido]);
  }
}
