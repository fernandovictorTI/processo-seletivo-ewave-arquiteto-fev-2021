import * as comandaActions from './comandas.actions';
import {AppAction} from '../../app.action';
import {createFeatureSelector, createSelector} from '@ngrx/store';
import { Comanda } from '../shared/comanda';

export interface State {
  data: Comanda[];
  selected: Comanda;
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
    case comandaActions.OBTER_COMANDAS:
      return {
        ...state,
        action: comandaActions.OBTER_COMANDAS,
        done: false,
        selected: null,
        error: null
      };
    case comandaActions.OBTER_COMANDAS_SUCCESS:
      return {
        ...state,
        data: action.payload,
        done: true,
        selected: null,
        error: null
      };
    case comandaActions.OBTER_COMANDAS_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };
      
    case comandaActions.OBTER_COMANDA:
      return {
        ...state,
        action: comandaActions.OBTER_COMANDA,
        done: false,
        selected: null,
        error: null
      };
    case comandaActions.OBTER_COMANDA_SUCCESS:
      return {
        ...state,
        selected: action.payload,
        done: true,
        error: null
      };
    case comandaActions.OBTER_COMANDA_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
      
    case comandaActions.CRIAR_COMANDA:
      return {
        ...state,
        selected: action.payload,
        action: comandaActions.CRIAR_COMANDA,
        done: false,
        error: null
      };
    case comandaActions.CRIAR_COMANDA_SUCCESS:
      {
        const newComanda = {
          ...state.selected,
          id: action.payload
        };
        const data = [
          ...state.data,
          newComanda
        ];
        return {
          ...state,
          data,
          selected: null,
          error: null,
          done: true
        };
      }
    case comandaActions.CRIAR_COMANDA_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

export const obterComandasState = createFeatureSelector <State> ('comandas');
export const obterAllComandas = createSelector(obterComandasState, (state: State) => state.data);
export const obterComanda = createSelector(obterComandasState, (state: State) => {
  if (state.action === comandaActions.OBTER_COMANDA && state.done) {
    return state.selected;
  } else {
    return null;
  }

});
export const isCreated = createSelector(obterComandasState, (state: State) =>
 state.action === comandaActions.CRIAR_COMANDA && state.done && !state.error);

export const obterCriarError = createSelector(obterComandasState, (state: State) => {
  return state.action === comandaActions.CRIAR_COMANDA
    ? state.error
   : null;
});
export const obterComandasError = createSelector(obterComandasState, (state: State) => {
  return state.action === comandaActions.OBTER_COMANDAS
    ? state.error
   : null;
});
export const obterComandaError = createSelector(obterComandasState, (state: State) => {
  return state.action === comandaActions.OBTER_COMANDA
    ? state.error
   : null;
});