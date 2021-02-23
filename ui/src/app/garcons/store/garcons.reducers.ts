import * as comandaActions from './garcons.actions';
import {AppAction} from '../../app.action';
import {createFeatureSelector, createSelector} from '@ngrx/store';
import { Garcom } from '../shared/garcom';

export interface State {
  data: Garcom[];
  selected: Garcom;
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
    case comandaActions.OBTER_GARCONS:
      return {
        ...state,
        action: comandaActions.OBTER_GARCONS,
        done: false,
        selected: null,
        error: null
      };
    case comandaActions.OBTER_GARCONS_SUCCESS:
      return {
        ...state,
        data: action.payload,
        done: true,
        selected: null,
        error: null
      };
    case comandaActions.OBTER_GARCONS_ERROR:
      return {
        ...state,
        done: true,
        selected: null,
        error: action.payload
      };
      
    case comandaActions.OBTER_GARCOM:
      return {
        ...state,
        action: comandaActions.OBTER_GARCOM,
        done: false,
        selected: null,
        error: null
      };
    case comandaActions.OBTER_GARCOM_SUCCESS:
      return {
        ...state,
        selected: action.payload,
        done: true,
        error: null
      };
    case comandaActions.OBTER_GARCOM_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
      
    case comandaActions.CRIAR_GARCOM:
      return {
        ...state,
        selected: action.payload,
        action: comandaActions.CRIAR_GARCOM,
        done: false,
        error: null
      };
    case comandaActions.CRIAR_GARCOM_SUCCESS:
      {
        const newGarcom = {
          ...state.selected,
          id: action.payload
        };
        const data = [
          ...state.data,
          newGarcom
        ];
        return {
          ...state,
          data,
          selected: null,
          error: null,
          done: true
        };
      }
    case comandaActions.CRIAR_GARCOM_ERROR:
      return {
        ...state,
        selected: null,
        done: true,
        error: action.payload
      };
  }
  return state;
}

export const obterGarconsState = createFeatureSelector <State> ('garcons');
export const obterAllGarcons = createSelector(obterGarconsState, (state: State) => state.data);
export const obterGarcom = createSelector(obterGarconsState, (state: State) => {
  if (state.action === comandaActions.OBTER_GARCOM && state.done) {
    return state.selected;
  } else {
    return null;
  }

});
export const isCreated = createSelector(obterGarconsState, (state: State) =>
 state.action === comandaActions.CRIAR_GARCOM && state.done && !state.error);

export const obterCriarError = createSelector(obterGarconsState, (state: State) => {
  return state.action === comandaActions.CRIAR_GARCOM
    ? state.error
   : null;
});
export const obterGarconsError = createSelector(obterGarconsState, (state: State) => {
  return state.action === comandaActions.OBTER_GARCONS
    ? state.error
   : null;
});
export const obterGarcomError = createSelector(obterGarconsState, (state: State) => {
  return state.action === comandaActions.OBTER_GARCOM
    ? state.error
   : null;
});