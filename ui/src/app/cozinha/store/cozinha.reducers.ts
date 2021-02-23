import * as cozinhaActions from './cozinha.actions';
import { AppAction } from '../../app.action';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Cozinha } from '../shared/cozinha';

export interface State {
  data: Cozinha[];
  selected: Cozinha;
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
    case cozinhaActions.OBTER_COMANDAS_ABERTAS:
      return {
        ...state,
        action: cozinhaActions.OBTER_COMANDAS_ABERTAS,
        done: false,
        selected: null,
        error: null
      };
    case cozinhaActions.OBTER_COMANDAS_ABERTAS_SUCCESS:
      return {
        ...state,
        data: action.payload,
        done: true,
        selected: null,
        error: null
      };
    case cozinhaActions.OBTER_COMANDAS_ABERTAS_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };
  }
  return state;
}

export const obterComandasAbertasState = createFeatureSelector<State>('comandas-abertas');
export const obterAllComandasAbertas = createSelector(obterComandasAbertasState, (state: State) => state.data);
export const obterAllComandasError = createSelector(obterComandasAbertasState, (state: State) => {
  return state.action === cozinhaActions.OBTER_COMANDAS_ABERTAS
    ? state.error
    : null;
});