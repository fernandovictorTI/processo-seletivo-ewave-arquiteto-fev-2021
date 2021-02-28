import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { fromComandaActions } from '../store/comandas.actions';
import { ComandaState } from '../store/comandas.reducers';

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
    private store: Store<ComandaState>) {
  }

  ngOnInit() {
    this.iniciarFormulario();
  }

  voltar() {
    this.router.navigate(['/comandas']);
  }

  onSaveComanda() {
    let objetoSalvar = this.frm.getRawValue();
    this.store.dispatch(fromComandaActions.AdicionarComanda({ entity: objetoSalvar }));
  }

  iniciarFormulario() {
    this.frm = this.fb.group({
      numero: [],
    });
  }

  limparCampos() {
    this.iniciarFormulario();
  }
}