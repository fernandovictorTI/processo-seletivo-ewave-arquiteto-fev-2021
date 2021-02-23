import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {AppState} from '../../app.state';
import {Pedido} from '../shared/pedido';
import {Observable} from 'rxjs';
import {obterAllPedidos} from '../store/pedidos.reducers';

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.component.html',
  styleUrls: ['./pedido-list.component.css']
})
export class PedidoListComponent implements OnInit {
  title = 'Histórico de Pedidos';
  pedidos: Observable<Pedido[]>;

  constructor(private store: Store<AppState>) {
  }

  ngOnInit() {
    this.pedidos = this.store.select(obterAllPedidos);
  }
}