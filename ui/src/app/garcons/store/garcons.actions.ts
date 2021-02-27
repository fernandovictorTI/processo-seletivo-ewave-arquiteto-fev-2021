import { Action, createAction, props} from '@ngrx/store';
import {Garcom} from '../shared/garcom';

export enum GarcomActionTypes {
  OBTER_GARCONS = '[ALL] Garcons',
  OBTER_GARCONS_SUCCESS = '[ALL] Garcons Success',
  OBTER_GARCONS_ERROR = '[ALL] Garcons Error',
  OBTER_GARCOM = '[GET] Garcom',
  OBTER_GARCOM_SUCCESS = '[GET] Garcons Success',
  OBTER_GARCOM_ERROR = '[GET] Garcons Error',
  CRIAR_GARCOM = '[CRIAR] Garcom', 
  CRIAR_GARCOM_SUCCESS = '[CRIAR] Garcom Success',
  CRIAR_GARCOM_ERROR = '[CRIAR] Garcom Error'
}

export const ObterGarcons = createAction(GarcomActionTypes.OBTER_GARCONS);

export const ObterGarconsSuccess = createAction(
  GarcomActionTypes.OBTER_GARCONS_SUCCESS,
  props<{data: Garcom[]}>()
);

export const ObterGarconsError = createAction(
  GarcomActionTypes.OBTER_GARCONS_ERROR,
  props<{ error: Error | any }>()
);

export const ObterGarcom = createAction(
  GarcomActionTypes.OBTER_GARCOM,
  props<{ id: string }>()
);

export const ObterGarcomSuccess = createAction(
  GarcomActionTypes.OBTER_GARCOM_SUCCESS,
  props<{garcom: Garcom}>()
);

export const ObterGarcomError = createAction(
  GarcomActionTypes.OBTER_GARCOM_ERROR,
  props<{ error: Error | any }>()
);

export const AdicionarGarcom = createAction(
  GarcomActionTypes.CRIAR_GARCOM,
  props<{entity: Garcom}>()
);

export const AdicionarGarcomSuccess = createAction(
  GarcomActionTypes.CRIAR_GARCOM_SUCCESS,
  props<{entity: Garcom}>()
);

export const AdicionarGarcomError = createAction(
  GarcomActionTypes.CRIAR_GARCOM_ERROR,
  props<{ error: Error | any }>()
);

export const fromGarcomActions = {
  ObterGarcons,
  ObterGarconsError,
  ObterGarconsSuccess,
  ObterGarcom,
  ObterGarcomSuccess,
  ObterGarcomError,
  AdicionarGarcom,
  AdicionarGarcomError,
  AdicionarGarcomSuccess
};
