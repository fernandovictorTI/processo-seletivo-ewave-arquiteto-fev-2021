import * as produtoActions from './produtos.actions';
import {AppAction} from '../../app.action';
import {createFeatureSelector, createSelector} from '@ngrx/store';
import { Produto } from '../shared/produto';

export interface State {
  data: Produto[];
  selected: Produto;
  action: string;
  done: boolean;
  error?: Error;
}

const initialState: State = {
  data: [],
  selected: null,
  action: null,
  done: false,
  error: null
};

export function reducer(state = initialState, action: AppAction): State {
  switch (action.type) {
    case produtoActions.OBTER_PRODUTOS:
      return {
        ...state,
        action: produtoActions.OBTER_PRODUTOS,
        done: false,
        selected: null,
        error: null
      };
    case produtoActions.OBTER_PRODUTOS_SUCCESS:
      return {
        ...state,
        data: action.payload,
        done: true,
        selected: null,
        error: null
      };
    case produtoActions.OBTER_PRODUTOS_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };
      
    case produtoActions.OBTER_PRODUTO:
      return {
        ...state,
        action: produtoActions.OBTER_PRODUTO,
        done: false,
        selected: null,
        error: null
      };
    case produtoActions.OBTER_PRODUTO_SUCCESS:
      return {
        ...state,
        selected: action.payload,
        done: true,
        error: null
      };
    case produtoActions.OBTER_PRODUTO_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
      
    case produtoActions.CRIAR_PRODUTO:
      return {
        ...state,
        selected: action.payload,
        action: produtoActions.CRIAR_PRODUTO,
        done: false,
        error: null
      };
    case produtoActions.CRIAR_PRODUTO_SUCCESS:
      {
        const newProduto = {
          ...state.selected,
          id: action.payload
        };
        const data = [
          ...state.data,
          newProduto
        ];
        return {
          ...state,
          data,
          selected: null,
          error: null,
          done: true
        };
      }
    case produtoActions.CRIAR_PRODUTO_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

export const obterProdutosState = createFeatureSelector <State> ('produtos');
export const obterAllProdutos = createSelector(obterProdutosState, (state: State) => state.data);
export const obterProduto = createSelector(obterProdutosState, (state: State) => {
  if (state.action === produtoActions.OBTER_PRODUTO && state.done) {
    return state.selected;
  } else {
    return null;
  }

});
export const isCreated = createSelector(obterProdutosState, (state: State) =>
 state.action === produtoActions.CRIAR_PRODUTO && state.done && !state.error);

export const obterCriarError = createSelector(obterProdutosState, (state: State) => {
  return state.action === produtoActions.CRIAR_PRODUTO
    ? state.error
   : null;
});
export const obterProdutosError = createSelector(obterProdutosState, (state: State) => {
  return state.action === produtoActions.OBTER_PRODUTOS
    ? state.error
   : null;
});
export const obterProdutoError = createSelector(obterProdutosState, (state: State) => {
  return state.action === produtoActions.OBTER_PRODUTO
    ? state.error
   : null;
});