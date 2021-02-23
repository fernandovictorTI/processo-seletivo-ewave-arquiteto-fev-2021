import * as criarPedidoActions from './criarpedido.actions';
import { AppAction } from '../../app.action';
import { createFeatureSelector, createSelector, MemoizedSelector } from '@ngrx/store';
import { Pedido } from '../shared/pedido';
import { Actions } from './criarpedido.actions';

export interface State {
  data: Pedido | null;
  isLoading: boolean;
  error?: Error;
  pedidoCriado: boolean;
}

const initialState: State = {
  data: null,
  isLoading: false,
  error: null,
  pedidoCriado: false
};

export function reducer(state = initialState, action: Actions): State {
  switch (action.type) {
    case criarPedidoActions.CRIAR_PEDIDO:
      return {
        ...state,
        isLoading: true,
        error: null,
        pedidoCriado: false
      };
    case criarPedidoActions.CRIAR_PEDIDO_SUCCESS:
      return {
        ...state,
        data: action.payload,
        error: null,
        isLoading: false,
        pedidoCriado: true
      };
    case criarPedidoActions.CRIAR_PEDIDO_ERROR:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
        pedidoCriado: false
      };

    case criarPedidoActions.CRIAR_PEDIDO_CANCELAR_ASSINATURA:
      return initialState;
  }
  return state;
}

const obterError = (state: State): any => (state.error && !state.isLoading) ? state.error : null;

const obterIsLoading = (state: State): boolean => state.isLoading;

const obterPedidoCriado = (state: State): any => state.pedidoCriado ? state.data : null;

export const selectCriarPedidoState: MemoizedSelector<
  object,
  State
> = createFeatureSelector<State>('criarpedido');

export const selectCriarPedidoError: MemoizedSelector<object, any> = createSelector(
  selectCriarPedidoState,
  obterError
);

export const selectCriarPedidoIsLoading: MemoizedSelector<
  object,
  boolean
> = createSelector(selectCriarPedidoState, obterIsLoading);

export const selectCriarPedido: MemoizedSelector<
  object,
  Pedido
> = createSelector(selectCriarPedidoState, obterPedidoCriado);