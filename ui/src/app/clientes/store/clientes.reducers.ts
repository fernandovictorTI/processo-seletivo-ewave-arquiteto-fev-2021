import * as clienteActions from './clientes.actions';
import {AppAction} from '../../app.action';
import {createFeatureSelector, createSelector} from '@ngrx/store';
import { Cliente } from '../shared/cliente';

export interface State {
  data: Cliente[];
  selected: Cliente;
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
    case clienteActions.OBTER_CLIENTES:
      return {
        ...state,
        action: clienteActions.OBTER_CLIENTES,
        done: false,
        selected: null,
        error: null
      };
    case clienteActions.OBTER_CLIENTES_SUCCESS:
      return {
        ...state,
        data: action.payload,
        done: true,
        selected: null,
        error: null
      };
    case clienteActions.OBTER_CLIENTES_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };
      
    case clienteActions.OBTER_CLIENTE:
      return {
        ...state,
        action: clienteActions.OBTER_CLIENTE,
        done: false,
        selected: null,
        error: null
      };
    case clienteActions.OBTER_CLIENTE_SUCCESS:
      return {
        ...state,
        selected: action.payload,
        done: true,
        error: null
      };
    case clienteActions.OBTER_CLIENTE_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
      
    case clienteActions.CRIAR_CLIENTE:
      return {
        ...state,
        selected: action.payload,
        action: clienteActions.CRIAR_CLIENTE,
        done: false,
        error: null
      };
    case clienteActions.CRIAR_CLIENTE_SUCCESS:
      {
        const newCliente = {
          ...state.selected,
          id: action.payload
        };
        const data = [
          ...state.data,
          newCliente
        ];
        return {
          ...state,
          data,
          selected: null,
          error: null,
          done: true
        };
      }
    case clienteActions.CRIAR_CLIENTE_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

export const obterClientesState = createFeatureSelector <State> ('clientes');
export const obterAllClientes = createSelector(obterClientesState, (state: State) => state.data);
export const obterCliente = createSelector(obterClientesState, (state: State) => {
  if (state.action === clienteActions.OBTER_CLIENTE && state.done) {
    return state.selected;
  } else {
    return null;
  }

});
export const isCreated = createSelector(obterClientesState, (state: State) =>
 state.action === clienteActions.CRIAR_CLIENTE && state.done && !state.error);

export const obterCriarError = createSelector(obterClientesState, (state: State) => {
  return state.action === clienteActions.CRIAR_CLIENTE
    ? state.error
   : null;
});
export const obterClientesError = createSelector(obterClientesState, (state: State) => {
  return state.action === clienteActions.OBTER_CLIENTES
    ? state.error
   : null;
});
export const obterClienteError = createSelector(obterClientesState, (state: State) => {
  return state.action === clienteActions.OBTER_CLIENTE
    ? state.error
   : null;
});