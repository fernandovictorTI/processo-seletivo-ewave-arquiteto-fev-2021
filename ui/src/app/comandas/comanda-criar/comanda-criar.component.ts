import { Component, OnInit } from '@angular/core';
import { Comanda } from '../shared/comanda';
import { AppState } from '../../app.state';
import { Store } from '@ngrx/store';
import { AdicionarComanda } from '../store/comandas.actions';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-comanda-criar',
  templateUrl: './comanda-criar.component.html',
  styleUrls: ['./comanda-criar.component.css']
})
export class ComandaCreateComponent implements OnInit {
  frm: FormGroup;
  title = 'Criar uma nova comanda';

  constructor(private router: Router,
    private fb: FormBuilder,
    private store: Store<AppState>) {
  }

  ngOnInit() {
    this.iniciarFormulario();
  }

  voltar() {
    this.router.navigate(['/comandas']);
  }

  onSaveComanda() {
    const objetoSalvar = this.frm.getRawValue();
    this.store.dispatch(new AdicionarComanda(objetoSalvar));
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