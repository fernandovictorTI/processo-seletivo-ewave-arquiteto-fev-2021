import { Component, OnInit } from '@angular/core';
import { Cliente } from '../shared/cliente';
import { AppState } from '../../app.state';
import { Store } from '@ngrx/store';
import { AdicionarCliente } from '../store/clientes.actions';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cliente-criar',
  templateUrl: './cliente-criar.component.html',
  styleUrls: ['./cliente-criar.component.css']
})
export class ClienteCreateComponent implements OnInit {
  frm: FormGroup;
  title = 'Criar um novo cliente';

  constructor(private router: Router,
    private fb: FormBuilder,
    private store: Store<AppState>) {
  }

  ngOnInit() {
    this.iniciarFormulario();
  }

  voltar() {
    this.router.navigate(['/clientes']);
  }

  onSaveCliente() {
    const objetoSalvar = this.frm.getRawValue();
    this.store.dispatch(new AdicionarCliente(objetoSalvar));
  }

  iniciarFormulario() {
    this.frm = this.fb.group({
      nome: [],
    });
  }

  limparCampos() {
    this.iniciarFormulario();
  }
}