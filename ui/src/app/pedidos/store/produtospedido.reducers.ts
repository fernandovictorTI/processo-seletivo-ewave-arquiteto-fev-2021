import * as produtoPedidoActions from './produtospedido.actions';
import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { ProdutoPedido } from '../shared/pedido';

export const ENTITY_FEATURE_KEY = "produtospedido";

export interface ProdutoPedidoState extends EntityState<ProdutoPedido> {
  loaded: boolean;
  error: Error;
  isCreated: boolean;
  isRemoved: boolean;
}

export const adapter: EntityAdapter<ProdutoPedido> = createEntityAdapter<ProdutoPedido>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  isCreated: false,
  isRemoved: false
});

const _reducer = createReducer(
  initialState,

  on(produtoPedidoActions.AdicionarProdutoPedido, (state) => {
    state = {
      ...state,
      isCreated: false
    };
    return state;
  }),

  on(produtoPedidoActions.AdicionarProdutoPedidoSuccess, (state) => {
    state = {
      ...state,
      isCreated: true
    };
    return state;
  }),

  on(produtoPedidoActions.RemoverProdutoPedido, (state) => {
    state = {
      ...state,
      isRemoved: false
    };
    return state;
  }),

  on(produtoPedidoActions.RemoverProdutoPedidoSuccess, (state) => {
    state = {
      ...state,
      isRemoved: true
    };
    return state;
  }),
);

export function reducer(state: ProdutoPedidoState | undefined, action: Action) {
  return _reducer(state, action);
}