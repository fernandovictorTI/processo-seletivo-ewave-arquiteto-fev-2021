import {Action} from '@ngrx/store';
import {Garcom} from '../shared/garcom';

export const OBTER_GARCONS = '[ALL] Garcons';
export const OBTER_GARCONS_SUCCESS = '[ALL] Garcons Success';
export const OBTER_GARCONS_ERROR = '[ALL] Garcons Error';

export const OBTER_GARCOM = '[GET] Garcom';
export const OBTER_GARCOM_SUCCESS = '[GET] Garcons Success';
export const OBTER_GARCOM_ERROR = '[GET] Garcons Error';

export const CRIAR_GARCOM = '[CRIAR] Garcom';
export const CRIAR_GARCOM_SUCCESS = '[CRIAR] Garcom Success';
export const CRIAR_GARCOM_ERROR = '[CRIAR] Garcom Error';

export class ObterGarcons implements Action {
  readonly type = OBTER_GARCONS;

  constructor(public payload: number) {
  }
}

export class ObterGarconsSuccess implements Action {
  readonly type = OBTER_GARCONS_SUCCESS;

  constructor(public payload: Garcom[]) {
  }
}

export class ObterGarconsError implements Action {
  readonly type = OBTER_GARCONS_ERROR;

  constructor(public payload: Error) {
  }
}

export class ObterGarcom implements Action {
  readonly type = OBTER_GARCOM;

  constructor(public payload: string) {
  }
}

export class ObterGarcomSuccess implements Action {
  readonly type = OBTER_GARCOM_SUCCESS;

  constructor(public payload: Garcom) {
  }
}

export class ObterGarcomError implements Action {
  readonly type = OBTER_GARCOM_ERROR;

  constructor(public payload: Error) {
  }
}

export class AdicionarGarcom implements Action {
  readonly type = CRIAR_GARCOM;

  constructor(public payload: Garcom) {
  }
}

export class AdicionarGarcomSuccess implements Action {
  readonly type = CRIAR_GARCOM_SUCCESS;

  constructor(public payload: string) {
  }
}

export class AdicionarGarcomError implements Action {
  readonly type = CRIAR_GARCOM_ERROR;

  constructor(public payload: Error) {
  }
}
