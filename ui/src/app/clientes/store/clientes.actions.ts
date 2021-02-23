import {Action} from '@ngrx/store';
import {Cliente} from '../shared/cliente';

export const OBTER_CLIENTES = '[ALL] Clientes';
export const OBTER_CLIENTES_SUCCESS = '[ALL] Clientes Success';
export const OBTER_CLIENTES_ERROR = '[ALL] Clientes Error';

export const OBTER_CLIENTE = '[GET] Cliente';
export const OBTER_CLIENTE_SUCCESS = '[GET] Clientes Success';
export const OBTER_CLIENTE_ERROR = '[GET] Clientes Error';

export const CRIAR_CLIENTE = '[CRIAR] Cliente';
export const CRIAR_CLIENTE_SUCCESS = '[CRIAR] Cliente Success';
export const CRIAR_CLIENTE_ERROR = '[CRIAR] Cliente Error';

export class ObterClientes implements Action {
  readonly type = OBTER_CLIENTES;

  constructor(public payload: number) {
  }
}

export class ObterClientesSuccess implements Action {
  readonly type = OBTER_CLIENTES_SUCCESS;

  constructor(public payload: Cliente[]) {
  }
}

export class ObterClientesError implements Action {
  readonly type = OBTER_CLIENTES_ERROR;

  constructor(public payload: Error) {
  }
}

export class ObterCliente implements Action {
  readonly type = OBTER_CLIENTE;

  constructor(public payload: string) {
  }
}

export class ObterClienteSuccess implements Action {
  readonly type = OBTER_CLIENTE_SUCCESS;

  constructor(public payload: Cliente) {
  }
}

export class ObterClienteError implements Action {
  readonly type = OBTER_CLIENTE_ERROR;

  constructor(public payload: Error) {
  }
}

export class AdicionarCliente implements Action {
  readonly type = CRIAR_CLIENTE;

  constructor(public payload: Cliente) {
  }
}

export class AdicionarClienteSuccess implements Action {
  readonly type = CRIAR_CLIENTE_SUCCESS;

  constructor(public payload: string) {
  }
}

export class AdicionarClienteError implements Action {
  readonly type = CRIAR_CLIENTE_ERROR;

  constructor(public payload: Error) {
  }
}
