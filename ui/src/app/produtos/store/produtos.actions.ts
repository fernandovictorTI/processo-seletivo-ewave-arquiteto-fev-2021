import {Action} from '@ngrx/store';
import {Produto} from '../shared/produto';

export const OBTER_PRODUTOS = '[ALL] Produtos';
export const OBTER_PRODUTOS_SUCCESS = '[ALL] Produtos Success';
export const OBTER_PRODUTOS_ERROR = '[ALL] Produtos Error';

export const OBTER_PRODUTO = '[GET] Produto';
export const OBTER_PRODUTO_SUCCESS = '[GET] Produtos Success';
export const OBTER_PRODUTO_ERROR = '[GET] Produtos Error';

export const CRIAR_PRODUTO = '[CRIAR] Produto';
export const CRIAR_PRODUTO_SUCCESS = '[CRIAR] Produto Success';
export const CRIAR_PRODUTO_ERROR = '[CRIAR] Produto Error';

export class ObterProdutos implements Action {
  readonly type = OBTER_PRODUTOS;

  constructor(public payload: number) {
  }
}

export class ObterProdutosSuccess implements Action {
  readonly type = OBTER_PRODUTOS_SUCCESS;

  constructor(public payload: Produto[]) {
  }
}

export class ObterProdutosError implements Action {
  readonly type = OBTER_PRODUTOS_ERROR;

  constructor(public payload: Error) {
  }
}

export class ObterProduto implements Action {
  readonly type = OBTER_PRODUTO;

  constructor(public payload: string) {
  }
}

export class ObterProdutoSuccess implements Action {
  readonly type = OBTER_PRODUTO_SUCCESS;

  constructor(public payload: Produto) {
  }
}

export class ObterProdutoError implements Action {
  readonly type = OBTER_PRODUTO_ERROR;

  constructor(public payload: Error) {
  }
}

export class AdicionarProduto implements Action {
  readonly type = CRIAR_PRODUTO;

  constructor(public payload: Produto) {
  }
}

export class AdicionarProdutoSuccess implements Action {
  readonly type = CRIAR_PRODUTO_SUCCESS;

  constructor(public payload: string) {
  }
}

export class AdicionarProdutoError implements Action {
  readonly type = CRIAR_PRODUTO_ERROR;

  constructor(public payload: Error) {
  }
}
