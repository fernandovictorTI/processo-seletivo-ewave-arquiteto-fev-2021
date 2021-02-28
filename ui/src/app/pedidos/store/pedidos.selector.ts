import { createFeatureSelector, createSelector } from "@ngrx/store";
import { PedidoState, ENTITY_FEATURE_KEY, selectAll } from "./pedidos.reducers";

const getEntityState = createFeatureSelector<PedidoState>(ENTITY_FEATURE_KEY);

export const selectObterPedidos = createSelector(
    getEntityState,
    selectAll
);

export const selectObterPedido = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.selected
);