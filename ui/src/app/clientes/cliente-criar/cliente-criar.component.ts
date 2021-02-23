import {Component, OnInit} from '@angular/core';
import {Cliente} from '../shared/cliente';
import {AppState} from '../../app.state';
import {Store} from '@ngrx/store';
import {AdicionarCliente} from '../store/clientes.actions';
import {Router} from '@angular/router';

@Component({
  selector: 'app-cliente-criar',
  templateUrl: './cliente-criar.component.html',
  styleUrls: ['./cliente-criar.component.css']
})
export class ClienteCreateComponent implements OnInit {
  title = 'Criar um novo cliente';
  cliente: Cliente = new Cliente();

  constructor(private router: Router,
              private store: Store<AppState>) {
  }

  ngOnInit() {
  }

  voltar() {
    this.router.navigate(['/clientes']);
  }

  onSaveCliente() {
    this.store.dispatch(new AdicionarCliente(this.cliente));
  }

  limparCampos() {
    this.cliente.nome = '';
  }
}