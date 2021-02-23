import { Action } from '@ngrx/store';
import { Pedido } from '../shared/pedido';

export const CRIAR_PEDIDO = '[CRIAR] Pedido';
export const CRIAR_PEDIDO_SUCCESS = '[CRIAR] Pedido Success';
export const CRIAR_PEDIDO_ERROR = '[CRIAR] Pedido Error';
export const CRIAR_PEDIDO_CANCELAR_ASSINATURA = '[CRIAR] Pedido Cancelar Assinatura';

export class AdicionarPedido implements Action {
  readonly type = CRIAR_PEDIDO;

  constructor(public payload: Pedido) {
  }
}

export class AdicionarPedidoSuccess implements Action {
  readonly type = CRIAR_PEDIDO_SUCCESS;

  constructor(public payload: Pedido) {
  }
}

export class AdicionarPedidoError implements Action {
  readonly type = CRIAR_PEDIDO_ERROR;

  constructor(public payload: Error) {
  }
}

export class AdicionarPedidoCancelarAssinatura implements Action {
  readonly type = CRIAR_PEDIDO_CANCELAR_ASSINATURA;
}

export type Actions = AdicionarPedido | AdicionarPedidoSuccess | AdicionarPedidoError | AdicionarPedidoCancelarAssinatura;