import { Component, OnInit } from '@angular/core';
import { AppState } from '../../app.state';
import { Store } from '@ngrx/store';
import { AdicionarProduto } from '../store/produtos.actions';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-produto-criar',
  templateUrl: './produto-criar.component.html',
  styleUrls: ['./produto-criar.component.css']
})
export class ProdutoCreateComponent implements OnInit {
  frm: FormGroup;
  title = 'Criar um novo produto';

  constructor(private router: Router,
    private fb: FormBuilder,
    private store: Store<AppState>) {
  }

  ngOnInit() {
    this.iniciarFormulario();
  }

  voltar() {
    this.router.navigate(['/produtos']);
  }

  onSaveProduto() {
    const objetoSalvar = this.frm.getRawValue();
    this.store.dispatch(new AdicionarProduto(objetoSalvar));
  }

  iniciarFormulario() {
    this.frm = this.fb.group({
      nome: [],
      valor: []
    });
  }

  limparCampos() {
    this.iniciarFormulario();
  }
}