import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ComandaState, ENTITY_FEATURE_KEY, selectAll, selectIds, selectTotal } from "./comandas.reducers";

const getEntityState = createFeatureSelector<ComandaState>(ENTITY_FEATURE_KEY);

export const selectEntityIds = createSelector(
    getEntityState,
    selectIds
);

export const selectObterComandas = createSelector(
    getEntityState,
    selectAll
);

export const foiCarregadoComandas = createSelector(
    getEntityState,
    state => state.loaded
);

export const selectComandasQuantidade = createSelector(
    getEntityState,
    selectTotal
);

export const selectObterComanda = createSelector(
    getEntityState,
    (state: ComandaState, prop: { id: string }) => state.entities[prop.id]
);

export const selectComandaCarregado = createSelector(
    getEntityState,
    state => state.loaded
);

export const isCreated = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.isCreated
);

