import { createAction, props } from '@ngrx/store';
import { Cozinha } from '../shared/cozinha';

export enum CozinhaActionTypes {
  OBTER_COMANDAS_ABERTAS = '[ALL] Comandas-Abertas',
  OBTER_COMANDAS_ABERTAS_SUCCESS = '[ALL] Comandas-Abertas-Success',
  ALTERAR_SITUACAOPEDIDO = '[ALTERAR] Situacao Pedido',
  ALTERAR_SITUACAOPEDIDO_SUCCESS = '[ALTERAR] Situacao Pedido Success'
}

export const ObterComandasAbertas = createAction(CozinhaActionTypes.OBTER_COMANDAS_ABERTAS);

export const ObterComandasAbertasSuccess = createAction(
  CozinhaActionTypes.OBTER_COMANDAS_ABERTAS_SUCCESS,
  props<{ data: Cozinha[] }>()
);

export const AlterarSituacaoPedido = createAction(
  CozinhaActionTypes.ALTERAR_SITUACAOPEDIDO,
  props<{ idPedido: string, situacaoPedido: number }>()
);

export const AlterarSituacaoPedidoSuccess = createAction(
  CozinhaActionTypes.ALTERAR_SITUACAOPEDIDO_SUCCESS,
  props<{ msg: string }>()
);

export const fromCozinhaActions = {
  ObterComandasAbertas,
  ObterComandasAbertasSuccess,
  AlterarSituacaoPedido,
  AlterarSituacaoPedidoSuccess
};