import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ClienteState, ENTITY_FEATURE_KEY, selectAll, selectIds, selectTotal } from "./clientes.reducers";

const getEntityState = createFeatureSelector<ClienteState>(ENTITY_FEATURE_KEY);

export const selectEntityIds = createSelector(
    getEntityState,
    selectIds
);

export const selectObterClientes = createSelector(
    getEntityState,
    selectAll
);

export const foiCarregadoClientes = createSelector(
    getEntityState,
    state => state.loaded
);

export const selectClientesQuantidade = createSelector(
    getEntityState,
    selectTotal
);

export const selectObterCliente = createSelector(
    getEntityState,
    (state: ClienteState, prop: { id: string }) => state.entities[prop.id]
);

export const selectClienteCarregado = createSelector(
    getEntityState,
    state => state.loaded
);

export const isCreated = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.isCreated
);

