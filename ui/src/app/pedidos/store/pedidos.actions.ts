import { Action } from '@ngrx/store';
import { Pedido } from '../shared/pedido';

export const OBTER_PEDIDOS = '[ALL] Pedidos';
export const OBTER_PEDIDOS_SUCCESS = '[ALL] Pedidos Success';
export const OBTER_PEDIDOS_ERROR = '[ALL] Pedidos Error';

export const OBTER_PEDIDO = '[GET] Pedido';
export const OBTER_PEDIDO_SUCCESS = '[GET] Pedidos Success';
export const OBTER_PEDIDO_ERROR = '[GET] Pedidos Error';

export class ObterPedidos implements Action {
  readonly type = OBTER_PEDIDOS;

  constructor(public payload: number) {
  }
}

export class ObterPedidosSuccess implements Action {
  readonly type = OBTER_PEDIDOS_SUCCESS;

  constructor(public payload: Pedido[]) {
  }
}

export class ObterPedidosError implements Action {
  readonly type = OBTER_PEDIDOS_ERROR;

  constructor(public payload: Error) {
  }
}

export class ObterPedido implements Action {
  readonly type = OBTER_PEDIDO;

  constructor(public payload: string) {
  }
}

export class ObterPedidoSuccess implements Action {
  readonly type = OBTER_PEDIDO_SUCCESS;

  constructor(public payload: Pedido) {
  }
}

export class ObterPedidoError implements Action {
  readonly type = OBTER_PEDIDO_ERROR;

  constructor(public payload: Error) {
  }
}