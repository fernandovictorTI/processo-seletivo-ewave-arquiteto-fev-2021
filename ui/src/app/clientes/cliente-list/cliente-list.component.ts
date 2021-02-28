import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Cliente } from '../shared/cliente';
import { Observable } from 'rxjs';
import { ClienteState } from '../store/clientes.reducers';
import { selectObterClientes } from '../store/clientes.selector';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  title = 'Clientes';
  clientes: Observable<Cliente[]>;

  constructor(private store: Store<ClienteState>) {
  }

  ngOnInit() {
    this.clientes = this.store.select(selectObterClientes);
  }
}