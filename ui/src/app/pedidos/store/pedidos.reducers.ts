import * as pedidoActions from './pedidos.actions';
import {AppAction} from '../../app.action';
import {createFeatureSelector, createSelector} from '@ngrx/store';
import { Pedido } from '../shared/pedido';

export interface State {
  data: Pedido[];
  selected: Pedido;
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
    case pedidoActions.OBTER_PEDIDOS:
      return {
        ...state,
        action: pedidoActions.OBTER_PEDIDOS,
        done: false,
        selected: null,
        error: null
      };
    case pedidoActions.OBTER_PEDIDOS_SUCCESS:
      return {
        ...state,
        data: action.payload,
        selected: null,
        done: true,
        error: null
      };
    case pedidoActions.OBTER_PEDIDOS_ERROR:
      return {
        ...state,
        done: true,
        error: action.payload,
        selected: null,
      };
      
    case pedidoActions.OBTER_PEDIDO:
      return {
        ...state,
        action: pedidoActions.OBTER_PEDIDO,        
        done: false,
        selected: null,
        error: null
      };
    case pedidoActions.OBTER_PEDIDO_SUCCESS:
      return {
        ...state,
        selected: action.payload,
        done: true,
        error: null
      };
    case pedidoActions.OBTER_PEDIDO_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

export const obterPedidosState = createFeatureSelector <State> ('pedidos');
export const obterAllPedidos = createSelector(obterPedidosState, (state: State) => state.data);
export const obterPedido = createSelector(obterPedidosState, (state: State) => {
  if (state.action === pedidoActions.OBTER_PEDIDO && state.done) {
    return state.selected;
  } else {
    return null;
  }
});

export const obterPedidosError = createSelector(obterPedidosState, (state: State) => {
  return state.action === pedidoActions.OBTER_PEDIDOS
    ? state.error
   : null;
});
export const obterPedidoError = createSelector(obterPedidosState, (state: State) => {
  return state.action === pedidoActions.OBTER_PEDIDO
    ? state.error
   : null;
});