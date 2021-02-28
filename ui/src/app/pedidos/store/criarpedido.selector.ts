import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CriarPedidoState, ENTITY_FEATURE_KEY } from "./criarpedido.reducers";

const getEntityState = createFeatureSelector<CriarPedidoState>(ENTITY_FEATURE_KEY);

export const isCreated = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.isCreated
);