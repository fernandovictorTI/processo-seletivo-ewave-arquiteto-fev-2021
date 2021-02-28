import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

import { Cliente } from '../shared/cliente';
import * as clientesActions from './clientes.actions';

export const ENTITY_FEATURE_KEY = "clientes";

export interface ClienteState extends EntityState<Cliente> {
  loaded: boolean;
  error: Error;
  isCreated: boolean;
}

export const adapter: EntityAdapter<Cliente> = createEntityAdapter<Cliente>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  isCreated: false
});

const _reducer = createReducer(
  initialState,

  on(clientesActions.ObterClientesSuccess, (state, { data }) => {
    return adapter.addMany(data, {
      ...state,
      loaded: true
    });
  }),

  on(clientesActions.ObterClienteSuccess, (state, { cliente }) => {
    return adapter.addOne(cliente, state);
  }),

  on(clientesActions.AdicionarCliente, (state) => {
    state = {
      ...state,
      isCreated: false
    }
    return state;
  }),

  on(clientesActions.AdicionarClienteSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    }
    return adapter.addOne(entity, state);
  })
);

export function reducer(state: ClienteState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll, selectIds, selectTotal } = adapter.getSelectors();