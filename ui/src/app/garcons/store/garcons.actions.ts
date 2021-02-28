import { Action, createAction, props } from '@ngrx/store';
import { Garcom } from '../shared/garcom';

export enum GarcomActionTypes {
  OBTER_GARCONS = '[ALL] Garcons',
  OBTER_GARCONS_SUCCESS = '[ALL] Garcons Success',
  OBTER_GARCOM = '[GET] Garcom',
  OBTER_GARCOM_SUCCESS = '[GET] Garcons Success',
  CRIAR_GARCOM = '[CRIAR] Garcom',
  CRIAR_GARCOM_SUCCESS = '[CRIAR] Garcom Success',
}

export const ObterGarcons = createAction(
  GarcomActionTypes.OBTER_GARCONS,
  props<{ quantidade: number }>()
);

export const ObterGarconsSuccess = createAction(
  GarcomActionTypes.OBTER_GARCONS_SUCCESS,
  props<{ data: Garcom[] }>()
);

export const ObterGarcom = createAction(
  GarcomActionTypes.OBTER_GARCOM,
  props<{ id: string }>()
);

export const ObterGarcomSuccess = createAction(
  GarcomActionTypes.OBTER_GARCOM_SUCCESS,
  props<{ garcom: Garcom }>()
);

export const AdicionarGarcom = createAction(
  GarcomActionTypes.CRIAR_GARCOM,
  props<{ entity: Garcom }>()
);

export const AdicionarGarcomSuccess = createAction(
  GarcomActionTypes.CRIAR_GARCOM_SUCCESS,
  props<{ entity: Garcom }>()
);

export const fromGarcomActions = {
  ObterGarcons,
  ObterGarconsSuccess,
  ObterGarcom,
  ObterGarcomSuccess,
  AdicionarGarcom,
  AdicionarGarcomSuccess
};
