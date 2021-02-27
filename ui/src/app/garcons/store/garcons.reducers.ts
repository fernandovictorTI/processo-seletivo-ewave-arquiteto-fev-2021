import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

import { Garcom } from '../shared/garcom';
import * as comandaActions from './garcons.actions';

export const ENTITY_FEATURE_KEY = "garcons";

export interface GarcomState extends EntityState<Garcom> {
  loaded: boolean;
  error: Error;
  isCreated: boolean;
}

export const adapter: EntityAdapter<Garcom> = createEntityAdapter<Garcom>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  isCreated: false
});

const _reducer = createReducer(
  initialState,
  
  on(comandaActions.ObterGarconsSuccess, (state, { data }) => {
    return adapter.addMany(data || [], {
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

  on(comandaActions.AdicionarGarcomSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    }
    return adapter.addOne(entity, state);
  }),

  on(comandaActions.AdicionarGarcomError, (state, { error }) => {
    console.log(error);
    return {
      ...state,
      error
    };
  })
);

export function reducer(state: GarcomState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll, selectIds } = adapter.getSelectors();