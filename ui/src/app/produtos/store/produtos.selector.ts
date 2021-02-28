import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProdutoState, ENTITY_FEATURE_KEY } from "./produtos.reducers";
import { selectAll, selectIds, selectTotal } from './produtos.reducers';

const getEntityState = createFeatureSelector<ProdutoState>(ENTITY_FEATURE_KEY);

export const selectEntityIds = createSelector(
    getEntityState,
    selectIds
);

export const selectObterProdutos = createSelector(
    getEntityState,
    selectAll
);

export const foiCarregadoProdutos = createSelector(
    getEntityState,
    state => state.loaded
);

export const selectProdutosQuantidade = createSelector(
    getEntityState,
    selectTotal
);

export const selectObterProduto = createSelector(
    getEntityState,
    (state: ProdutoState, prop: { id: string }) => state.entities[prop.id]
);

export const selectProdutoCarregado = createSelector(
    getEntityState,
    state => state.loaded
);

export const isCreated = createSelector(getEntityState,
    getEntityState,
    state => !state.error && state.isCreated
);

