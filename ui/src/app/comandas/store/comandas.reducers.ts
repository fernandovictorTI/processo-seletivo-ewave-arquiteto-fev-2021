import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

import { Comanda } from '../shared/comanda';
import * as comandasActions from './comandas.actions';

export const ENTITY_FEATURE_KEY = "comandas";

export interface ComandaState extends EntityState<Comanda> {
  loaded: boolean;
  error: Error;
  isCreated: boolean;
}

export const adapter: EntityAdapter<Comanda> = createEntityAdapter<Comanda>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  isCreated: false
});

const _reducer = createReducer(
  initialState,

  on(comandasActions.ObterComandasSuccess, (state, { data }) => {

    state = {
      ...initialState,
      loaded: true
    };

    return adapter.addMany(data || [], state);
  }),

  on(comandasActions.ObterComandaSuccess, (state, { comanda }) => {
    return adapter.addOne(comanda, state);
  }),

  on(comandasActions.AdicionarComanda, (state, { entity }) => {
    state = {
      ...state,
      isCreated: false,
    };
    return state;
  }),

  on(comandasActions.AdicionarComandaSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    };

    entity = {
      ...entity,
      isAberta: true
    };

    return adapter.addOne(entity, state);
  })
);

export function reducer(state: ComandaState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll, selectIds, selectTotal } = adapter.getSelectors();