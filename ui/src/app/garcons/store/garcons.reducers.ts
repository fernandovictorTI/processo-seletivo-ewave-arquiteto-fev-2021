import * as comandaActions from './garcons.actions';
import { AppAction } from '../../app.action';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import {createFeatureSelector, createSelector, createReducer, on, Action } from '@ngrx/store';
import { Garcom } from '../shared/garcom';

export interface GarcomState extends EntityState<Garcom> {
  loaded: boolean;
  error: Error;
}

export const ENTITY_FEATURE_KEY = "garcons";

export const adapter: EntityAdapter<Garcom> = createEntityAdapter<Garcom>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null
});

const _reducer = createReducer(
  initialState,
  
  on(comandaActions.ObterGarconsSuccess, (state, { data })=> {
    return adapter.setAll(data, {
      ...state,
      loaded: true
    });
  }),

  on(comandaActions.ObterGarconsError, (state, { error })=> {
    return {
      ...state,
      error
    };
  }),

  on(comandaActions.ObterGarcomSuccess, (state, { garcom }) => {
    return adapter.addOne(garcom, state);
  }),

  on(comandaActions.ObterGarcomError, (state, { error }) => {
    return {
      ...state,
      error
    };
  }),

  on(comandaActions.AdicionarGarcom, (state, { entity }) => {
    return adapter.addOne(entity, state);
  }),

  on(comandaActions.AdicionarGarcomError, (state, { error }) => {
    return {
      ...state,
      error
    };
  })
);

export function reducer(state: GarcomState | undefined, action: Action) {
  return _reducer(state, action);
}