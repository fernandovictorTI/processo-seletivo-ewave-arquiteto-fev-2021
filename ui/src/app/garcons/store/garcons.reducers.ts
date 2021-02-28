import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

import { Garcom } from '../shared/garcom';
import * as garconsActions from './garcons.actions';

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

  on(garconsActions.ObterGarconsSuccess, (state, { data }) => {
    return adapter.addMany(data, {
      ...state,
      loaded: true
    });
  }),

  on(garconsActions.ObterGarcomSuccess, (state, { garcom }) => {
    return adapter.addOne(garcom, state);
  }),

  on(garconsActions.AdicionarGarcom, (state) => {
    state = {
      ...state,
      isCreated: false
    }
    return state;
  }),

  on(garconsActions.AdicionarGarcomSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    }
    return adapter.addOne(entity, state);
  })
);

export function reducer(state: GarcomState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll, selectIds, selectTotal } = adapter.getSelectors();