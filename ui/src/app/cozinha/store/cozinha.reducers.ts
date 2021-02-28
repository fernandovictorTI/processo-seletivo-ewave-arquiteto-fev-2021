import { Action, createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';

import { Cozinha } from '../shared/cozinha';
import * as cozinhaActions from './cozinha.actions';

export const ENTITY_FEATURE_KEY = "comandas-abertas";

export interface CozinhaState extends EntityState<Cozinha> {
  loaded: boolean;
  error: Error;
  situacaoAlterada: boolean;
}

export const adapter: EntityAdapter<Cozinha> = createEntityAdapter<Cozinha>(
  {
    selectId: (cozinha: Cozinha) => cozinha.idComanda,
  }
);

export const initialState = adapter.getInitialState({
  loaded: false,
  error: null,
  situacaoAlterada: false
});

const _reducer = createReducer(
  initialState,

  on(cozinhaActions.ObterComandasAbertasSuccess, (state, { data }) => {

    state = {
      ...initialState,
      loaded: true
    };

    return adapter.addMany(data || [], state);
  }),

  on(cozinhaActions.AlterarSituacaoPedido, (state) => {

    state = {
      ...state,
      situacaoAlterada: false
    }

    return state;
  }),

  on(cozinhaActions.AlterarSituacaoPedidoSuccess, (state) => {

    state = {
      ...state,
      situacaoAlterada: true
    }

    return state;
  })



);

export function reducer(state: CozinhaState | undefined, action: Action) {
  return _reducer(state, action);
}

export const { selectAll } = adapter.getSelectors();