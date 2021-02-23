import {Action} from '@ngrx/store';
import { Cozinha } from '../shared/cozinha';

export const OBTER_COMANDAS_ABERTAS = '[ALL] Comandas-Abertas';
export const OBTER_COMANDAS_ABERTAS_SUCCESS = '[ALL] Comandas-Abertas-Success';
export const OBTER_COMANDAS_ABERTAS_ERROR = '[ALL] Comandas-Abertas-Error';

export class ObterComandasAbertas implements Action {
  readonly type = OBTER_COMANDAS_ABERTAS;
}

export class ObterComandasAbertasSuccess implements Action {
  readonly type = OBTER_COMANDAS_ABERTAS_SUCCESS;

  constructor(public payload: Cozinha[]) {
  }
}

export class ObterComandasAbertasError implements Action {
  readonly type = OBTER_COMANDAS_ABERTAS_ERROR;

  constructor(public payload: Error) {
  }
}
