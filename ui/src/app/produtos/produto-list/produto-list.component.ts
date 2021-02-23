import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {AppState} from '../../app.state';
import {Produto} from '../shared/produto';
import {Observable} from 'rxjs';
import {obterAllProdutos} from '../store/produtos.reducers';

@Component({
  selector: 'app-produto-list',
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.css']
})
export class ProdutoListComponent implements OnInit {
  title = 'Produtos';
  produtos: Observable<Produto[]>;

  constructor(private store: Store<AppState>) {
  }

  ngOnInit() {
    this.produtos = this.store.select(obterAllProdutos);
  }
}