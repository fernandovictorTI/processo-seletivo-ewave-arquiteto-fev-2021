import { createAction, props } from '@ngrx/store';
import { Pedido } from '../shared/pedido';

export enum CriarPedidoActionTypes {
  CRIAR_PEDIDO = '[CRIAR] Pedido',
  CRIAR_PEDIDO_SUCCESS = '[CRIAR] Pedido Success'
}

export const CriarPedido = createAction(
  CriarPedidoActionTypes.CRIAR_PEDIDO,
  props<{ entity: Pedido }>()
);

export const CriarPedidoSuccess = createAction(
  CriarPedidoActionTypes.CRIAR_PEDIDO_SUCCESS,
  props<{ entity: Pedido }>()
);

export const fromCriarPedidoActions = {
  CriarPedido,
  CriarPedidoSuccess
};