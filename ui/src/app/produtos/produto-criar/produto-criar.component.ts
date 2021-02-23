import {Component, OnInit} from '@angular/core';
import {Produto} from '../shared/produto';
import {AppState} from '../../app.state';
import {Store} from '@ngrx/store';
import {AdicionarProduto} from '../store/produtos.actions';
import {Router} from '@angular/router';

@Component({
  selector: 'app-produto-criar',
  templateUrl: './produto-criar.component.html',
  styleUrls: ['./produto-criar.component.css']
})
export class ProdutoCreateComponent implements OnInit {
  title = 'Criar um novo produto';
  produto: Produto = new Produto();

  constructor(private router: Router,
              private store: Store<AppState>) {
  }

  ngOnInit() {
  }

  voltar() {
    this.router.navigate(['/produtos']);
  }

  onSaveProduto() {
    this.store.dispatch(new AdicionarProduto(this.produto));
  }

  limparCampos() {
    this.produto.nome = "";
    this.produto.valor = 0;
  }
}