import { Action, createAction, props } from '@ngrx/store';
import { Produto } from '../shared/produto';

export enum ProdutoActionTypes {
  OBTER_PRODUTOS = '[ALL] Produtos',
  OBTER_PRODUTOS_SUCCESS = '[ALL] Produtos Success',
  OBTER_PRODUTO = '[GET] Produto',
  OBTER_PRODUTO_SUCCESS = '[GET] Produtos Success',
  CRIAR_PRODUTO = '[CRIAR] Produto',
  CRIAR_PRODUTO_SUCCESS = '[CRIAR] Produto Success'
}

export const ObterProdutos = createAction(
  ProdutoActionTypes.OBTER_PRODUTOS,
  props<{ quantidade: number }>()
)

export const ObterProdutosSuccess = createAction(
  ProdutoActionTypes.OBTER_PRODUTOS_SUCCESS,
  props<{ data: Produto[] }>()
)

export const ObterProduto = createAction(
  ProdutoActionTypes.OBTER_PRODUTO,
  props<{ id: string }>()
)

export const ObterProdutoSuccess = createAction(
  ProdutoActionTypes.OBTER_PRODUTO_SUCCESS,
  props<{ entity: Produto }>()
)

export const AdicionarProduto = createAction(
  ProdutoActionTypes.CRIAR_PRODUTO,
  props<{ entity: Produto }>()
)

export const AdicionarProdutoSuccess = createAction(
  ProdutoActionTypes.CRIAR_PRODUTO_SUCCESS,
  props<{ entity: Produto }>()
)

export const fromProdutosActions = {
  ObterProdutos,
  ObterProdutosSuccess,
  ObterProduto,
  ObterProdutoSuccess,
  AdicionarProduto,
  AdicionarProdutoSuccess
};
