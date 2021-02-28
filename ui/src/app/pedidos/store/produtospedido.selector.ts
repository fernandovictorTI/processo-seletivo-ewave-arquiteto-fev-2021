import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProdutoPedidoState, ENTITY_FEATURE_KEY } from "./produtospedido.reducers";

const getEntityState = createFeatureSelector<ProdutoPedidoState>(ENTITY_FEATURE_KEY);

export const isCreatedProdutoPedido = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.isCreated
);

export const isRemovedProdutoPedido = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.isRemoved
);