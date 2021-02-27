import { Component, OnInit } from '@angular/core';
import { Garcom } from '../shared/garcom';
import { AppState } from '../../app.state';
import { Store } from '@ngrx/store';
import { fromGarcomActions } from '../store/garcons.actions';
import { Router } from '@angular/router';
import { GarcomState } from '../store/garcons.reducers';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-garcom-criar',
  templateUrl: './garcom-criar.component.html',
  styleUrls: ['./garcom-criar.component.css']
})
export class GarcomCreateComponent implements OnInit {
  title = 'Criar um novo garcom';
  frmGarcom: FormGroup;

  constructor(private router: Router,
    private fb: FormBuilder,
    private store: Store<GarcomState>) {
    this.iniciarFormulario();
  }

  ngOnInit() {
  }

  voltar() {
    this.router.navigate(['/garcons']);
  }

  onSaveGarcom() {
    const objetoSalvar = this.frmGarcom.getRawValue();
    this.store.dispatch(fromGarcomActions.AdicionarGarcom({ entity: objetoSalvar }));
  }

  iniciarFormulario() {
    this.frmGarcom = this.fb.group({
      nome: [],
      telefone: []
    });
  }

  limparCampos() {
    this.iniciarFormulario();
  }
}