import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CozinhaState, ENTITY_FEATURE_KEY, selectAll } from "./cozinha.reducers";

const getEntityState = createFeatureSelector<CozinhaState>(ENTITY_FEATURE_KEY);

export const selectObterComandasAbertas = createSelector(
    getEntityState,
    selectAll
);

export const foiCarregadoComandas = createSelector(
    getEntityState,
    state => state.loaded
);

export const selectSituacaoAlterada = createSelector(
    getEntityState,
    state => !state.error && state.situacaoAlterada
);