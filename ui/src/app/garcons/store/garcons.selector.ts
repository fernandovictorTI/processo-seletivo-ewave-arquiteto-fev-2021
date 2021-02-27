import { createFeatureSelector, createSelector } from "@ngrx/store";
import { GarcomState, ENTITY_FEATURE_KEY } from "./garcons.reducers";
import { selectAll, selectIds, selectTotal } from './garcons.reducers';
import * as  GarconsActions from './garcons.actions';

const getEntityState = createFeatureSelector<GarcomState>(ENTITY_FEATURE_KEY);

export const selectEntityIds = createSelector(
  getEntityState,
  selectIds
);

export const selectObterGarcons = createSelector(
  getEntityState,
  selectAll
);

export const foiCarregadoGarcons = createSelector(
  getEntityState,
  state => state.loaded
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

export const isCreated = createSelector(getEntityState,
  getEntityState,
  state => !state.error && state.isCreated
);

