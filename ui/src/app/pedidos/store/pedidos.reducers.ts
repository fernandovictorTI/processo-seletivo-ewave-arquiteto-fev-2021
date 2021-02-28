import * as pedidosActions from './pedidos.actions';
import { Pedido } from '../shared/pedido';
import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

export const ENTITY_FEATURE_KEY = "pedidos";

export interface PedidoState extends EntityState<Pedido> {
  loaded: boolean;
  error: Error;
  selected: Pedido;
  isCreated: boolean;
}

export const adapter: EntityAdapter<Pedido> = createEntityAdapter<Pedido>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  selected: null,
  isCreated: false
});

const _reducer = createReducer(
  initialState,

  on(pedidosActions.ObterPedidosSuccess, (state, { data }) => {
    return adapter.addMany(data || [], {
      ...initialState,
      loaded: true
    });
  }),

  on(pedidosActions.ObterPedidoSuccess, (state, { pedido }) => {

    state = {
      ...state,
      selected: pedido
    };

    return adapter.addOne(pedido, state);
  }),

  on(pedidosActions.CriarPedido, (state, { entity }) => {
    state = {
      ...state,
      isCreated: false,
    };
    return state;
  }),

  on(pedidosActions.CriarPedidoSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    };

    return adapter.addOne(entity, state);;
  })
);

export function reducer(state: PedidoState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll, selectIds, selectTotal } = adapter.getSelectors();