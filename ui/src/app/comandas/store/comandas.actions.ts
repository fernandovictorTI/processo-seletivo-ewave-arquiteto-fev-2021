import {Action} from '@ngrx/store';
import {Comanda} from '../shared/comanda';

export const OBTER_COMANDAS = '[ALL] Comandas';
export const OBTER_COMANDAS_SUCCESS = '[ALL] Comandas Success';
export const OBTER_COMANDAS_ERROR = '[ALL] Comandas Error';

export const OBTER_COMANDA = '[GET] Comanda';
export const OBTER_COMANDA_SUCCESS = '[GET] Comandas Success';
export const OBTER_COMANDA_ERROR = '[GET] Comandas Error';

export const CRIAR_COMANDA = '[CRIAR] Comanda';
export const CRIAR_COMANDA_SUCCESS = '[CRIAR] Comanda Success';
export const CRIAR_COMANDA_ERROR = '[CRIAR] Comanda Error';

export class ObterComandas implements Action {
  readonly type = OBTER_COMANDAS;

  constructor(public payload: number) {
  }
}

export class ObterComandasSuccess implements Action {
  readonly type = OBTER_COMANDAS_SUCCESS;

  constructor(public payload: Comanda[]) {
  }
}

export class ObterComandasError implements Action {
  readonly type = OBTER_COMANDAS_ERROR;

  constructor(public payload: Error) {
  }
}

export class ObterComanda implements Action {
  readonly type = OBTER_COMANDA;

  constructor(public payload: string) {
  }
}

export class ObterComandaSuccess implements Action {
  readonly type = OBTER_COMANDA_SUCCESS;

  constructor(public payload: Comanda) {
  }
}

export class ObterComandaError implements Action {
  readonly type = OBTER_COMANDA_ERROR;

  constructor(public payload: Error) {
  }
}

export class AdicionarComanda implements Action {
  readonly type = CRIAR_COMANDA;

  constructor(public payload: Comanda) {
  }
}

export class AdicionarComandaSuccess implements Action {
  readonly type = CRIAR_COMANDA_SUCCESS;

  constructor(public payload: string) {
  }
}

export class AdicionarComandaError implements Action {
  readonly type = CRIAR_COMANDA_ERROR;

  constructor(public payload: Error) {
  }
}
