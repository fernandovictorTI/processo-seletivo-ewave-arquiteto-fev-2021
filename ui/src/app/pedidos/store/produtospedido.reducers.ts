import * as pedidoActions from './produtospedido.actions';
import { AppAction } from '../../app.action';
import { createFeatureSelector, createSelector } from '@ngrx/store';

export interface State {
  selected: string;
  action: string;
  done: boolean;
  error?: Error;
}

const initialState: State = {
  selected: null,
  action: null,
  done: false,
  error: null
};

export function reducer(state = initialState, action: AppAction): State {
  switch (action.type) {

    case pedidoActions.CRIAR_PRODUTOPEDIDO:
      return {
        ...state,
        selected: action.payload,
        action: pedidoActions.CRIAR_PRODUTOPEDIDO,
        done: false,
        error: null
      };

    case pedidoActions.CRIAR_PRODUTOPEDIDO_SUCCESS:
      {
        return {
          ...state,
          error: null,
          done: true
        };
      }

    case pedidoActions.CRIAR_PRODUTOPEDIDO_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };

    case pedidoActions.REMOVER_PRODUTOPEDIDO:
      return {
        ...state,
        selected: action.payload,
        action: pedidoActions.REMOVER_PRODUTOPEDIDO,
        done: false,
        error: null
      };

    case pedidoActions.REMOVER_PRODUTOPEDIDO_SUCCESS:
      {
        return {
          ...state,
          error: null,
          done: true
        };
      }

    case pedidoActions.REMOVER_PRODUTOPEDIDO_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

export const produtoPedidosState = createFeatureSelector<State>('produtospedido');

export const isAdicionadoProdutoPedido = createSelector(produtoPedidosState, (state: State) =>
  state.action === pedidoActions.CRIAR_PRODUTOPEDIDO && state.done && !state.error);

export const getIdDoPedidoAoAdicionarProdutoPedido = createSelector(produtoPedidosState, (state: State) => {
  if (state.action === pedidoActions.CRIAR_PRODUTOPEDIDO && state.done && !state.error)
    return state.selected;
  else
    return null;
});

export const getIdDoPedidoAoRemoverProdutoPedido = createSelector(produtoPedidosState, (state: State) => {
  if (state.action === pedidoActions.REMOVER_PRODUTOPEDIDO && state.done && !state.error)
    return state.selected;
  else
    return null;
});

export const obterCriarError = createSelector(produtoPedidosState, (state: State) => {
  return state.action === pedidoActions.CRIAR_PRODUTOPEDIDO
    ? state.error
    : null;
});

export const foiRemovidoProdutoPedido = createSelector(produtoPedidosState, (state: State) =>
  state.action === pedidoActions.REMOVER_PRODUTOPEDIDO && state.done && !state.error);

export const foiRemovidoProdutoPedidoError = createSelector(produtoPedidosState, (state: State) => {
  return state.action === pedidoActions.REMOVER_PRODUTOPEDIDO
    ? state.error
    : null;
});