import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { Pedido } from '../shared/pedido';

import * as criarPedidoActions from './criarpedido.actions';

export const ENTITY_FEATURE_KEY = "criarpedido";

export interface CriarPedidoState extends EntityState<Pedido> {
  loaded: boolean;
  error: Error;
  isCreated: boolean;
}

export const adapter: EntityAdapter<Pedido> = createEntityAdapter<Pedido>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  isCreated: false
});

const _reducer = createReducer(
  initialState,

  on(criarPedidoActions.CriarPedido, (state, { entity }) => {
    state = {
      ...state,
      isCreated: false,
    };
    return state;
  }),

  on(criarPedidoActions.CriarPedidoSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    };

    return adapter.addOne(entity, state);;
  })
);

export function reducer(state: CriarPedidoState | undefined, action: Action) {
  return _reducer(state, action);
}