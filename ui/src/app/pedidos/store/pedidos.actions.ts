import { createAction, props } from '@ngrx/store';
import { Pedido } from '../shared/pedido';

export enum PedidosActionTypes {
  OBTER_PEDIDOS = '[ALL] Pedidos',
  OBTER_PEDIDOS_SUCCESS = '[ALL] Pedidos Success',
  OBTER_PEDIDO = '[GET] Pedido',
  OBTER_PEDIDO_SUCCESS = '[GET] Pedidos Success',
  CRIAR_PEDIDO = '[CRIAR] Pedido',
  CRIAR_PEDIDO_SUCCESS = '[CRIAR] Pedido Success'
}
export const ObterPedidos = createAction(
  PedidosActionTypes.OBTER_PEDIDOS,
  props<{ quantidade: number }>()
);

export const ObterPedidosSuccess = createAction(
  PedidosActionTypes.OBTER_PEDIDOS_SUCCESS,
  props<{ data: Pedido[] }>()
);

export const ObterPedido = createAction(
  PedidosActionTypes.OBTER_PEDIDO,
  props<{ id: string }>()
);

export const ObterPedidoSuccess = createAction(
  PedidosActionTypes.OBTER_PEDIDO_SUCCESS,
  props<{ pedido: Pedido }>()
);

export const CriarPedido = createAction(
  PedidosActionTypes.CRIAR_PEDIDO,
  props<{ entity: Pedido }>()
);

export const CriarPedidoSuccess = createAction(
  PedidosActionTypes.CRIAR_PEDIDO_SUCCESS,
  props<{ entity: Pedido }>()
);

export const fromPedidoActions = {
  ObterPedidos,
  ObterPedidosSuccess,
  ObterPedido,
  ObterPedidoSuccess,
  CriarPedido,
  CriarPedidoSuccess
};