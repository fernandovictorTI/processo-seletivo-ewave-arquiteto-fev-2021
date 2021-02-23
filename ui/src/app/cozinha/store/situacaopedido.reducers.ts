import * as situacaoPedidoActions from './situacaopedido.actions';
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

    case situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO:
      return {
        ...state,
        selected: action.payload,
        action: situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO,
        done: false,
        error: null
      };

    case situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO_SUCCESS:
      {
        return {
          ...state,
          error: null,
          done: true
        };
      }

    case situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };    
  }
  return state;
}

export const situacaoPedidosState = createFeatureSelector<State>('situacoespedido');

export const foiAlteradoSituacaoPedido = createSelector(situacaoPedidosState, (state: State) =>
  state.action === situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO && state.done && !state.error);

export const getIdDoPedidoAoAdicionarProdutoPedido = createSelector(situacaoPedidosState, (state: State) => {
  if (state.action === situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO && state.done && !state.error)
    return state.selected;
  else
    return null;
});

export const foiAlteradoSituacaoPedidoError = createSelector(situacaoPedidosState, (state: State) => {
  return state.action === situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO_ERROR
    ? state.error
    : null;
});