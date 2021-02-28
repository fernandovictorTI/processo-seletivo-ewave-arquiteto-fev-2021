import { createAction, props } from '@ngrx/store';
import { Comanda } from '../shared/comanda';

export enum ComandaActionTypes {
  OBTER_COMANDAS = '[ALL] Comandas',
  OBTER_COMANDAS_SUCCESS = '[ALL] Comandas Success',
  OBTER_COMANDA = '[GET] Comanda',
  OBTER_COMANDA_SUCCESS = '[GET] Comandas Success',
  CRIAR_COMANDA = '[CRIAR] Comanda',
  CRIAR_COMANDA_SUCCESS = '[CRIAR] Comanda Success',
}

export const ObterComandas = createAction(
  ComandaActionTypes.OBTER_COMANDAS,
  props<{ quantidade: number }>()
);

export const ObterComandasSuccess = createAction(
  ComandaActionTypes.OBTER_COMANDAS_SUCCESS,
  props<{ data: Comanda[] }>()
);

export const ObterComanda = createAction(
  ComandaActionTypes.OBTER_COMANDA,
  props<{ id: string }>()
);

export const ObterComandaSuccess = createAction(
  ComandaActionTypes.OBTER_COMANDA_SUCCESS,
  props<{ comanda: Comanda }>()
);

export const AdicionarComanda = createAction(
  ComandaActionTypes.CRIAR_COMANDA,
  props<{ entity: Comanda }>()
);

export const AdicionarComandaSuccess = createAction(
  ComandaActionTypes.CRIAR_COMANDA_SUCCESS,
  props<{ entity: Comanda }>()
);

export const fromComandaActions = {
  ObterComandas,
  ObterComandasSuccess,
  ObterComanda,
  ObterComandaSuccess,
  AdicionarComanda,
  AdicionarComandaSuccess
};
