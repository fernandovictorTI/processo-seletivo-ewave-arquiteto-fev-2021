import { createFeatureSelector, createSelector } from "@ngrx/store";

import { GarcomState, adapter, ENTITY_FEATURE_KEY } from "./garcons.reducers";

const getEntityState = createFeatureSelector<GarcomState>(ENTITY_FEATURE_KEY);

const { selectIds, selectAll, selectTotal } = adapter.getSelectors();

export const selectEntityIds = createSelector(
  getEntityState,
  selectIds
);

export const selectObterGarcons = createSelector(
  getEntityState,
  selectAll
);

export const selectGarconsQuantidade = createSelector(
  getEntityState,
  selectTotal
);

export const selectObterGarcom = createSelector(
  getEntityState,
  (state: GarcomState, prop: { id: string }) => state.entities[prop.id]
);

export const selectGarcomCarregado = createSelector(
  getEntityState,
  state => state.loaded
);

export const selectError = createSelector(
  getEntityState,
  state => state.error
);