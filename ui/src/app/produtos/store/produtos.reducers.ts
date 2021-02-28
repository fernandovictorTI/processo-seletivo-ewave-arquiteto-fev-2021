import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

import { Produto } from '../shared/produto';
import * as produtosActions from './produtos.actions';

export const ENTITY_FEATURE_KEY = "produtos";

export interface ProdutoState extends EntityState<Produto> {
  loaded: boolean;
  error: Error;
  isCreated: boolean;
}

export const adapter: EntityAdapter<Produto> = createEntityAdapter<Produto>();

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  isCreated: false
});

const _reducer = createReducer(
  initialState,

  on(produtosActions.ObterProdutosSuccess, (state, { data }) => {
    return adapter.addMany(data, {
      ...state,
      loaded: true
    });
  }),

  on(produtosActions.ObterProdutoSuccess, (state, { entity }) => {
    return adapter.addOne(entity, state);
  }),

  on(produtosActions.AdicionarProduto, (state) => {
    state = {
      ...state,
      isCreated: false
    }
    return state;
  }),

  on(produtosActions.AdicionarProdutoSuccess, (state, { entity }) => {
    state = {
      ...state,
      isCreated: true
    }
    return adapter.addOne(entity, state);
  })
);

export function reducer(state: ProdutoState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll, selectIds, selectTotal } = adapter.getSelectors();


