import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {AppState} from '../../app.state';
import {Cliente} from '../shared/cliente';
import {Observable} from 'rxjs';
import {obterAllClientes} from '../store/clientes.reducers';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  title = 'Clientes';
  clientes: Observable<Cliente[]>;

  constructor(private store: Store<AppState>) {
  }

  ngOnInit() {
    this.clientes = this.store.select(obterAllClientes);
  }
}