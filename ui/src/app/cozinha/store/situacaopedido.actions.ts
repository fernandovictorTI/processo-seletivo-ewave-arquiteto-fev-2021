import { Action } from '@ngrx/store';

export const ALTERAR_SITUACAOPEDIDO = '[ALTERAR] Situacao Pedido';
export const ALTERAR_SITUACAOPEDIDO_SUCCESS = '[ALTERAR] Situacao Pedido Success';
export const ALTERAR_SITUACAOPEDIDO_ERROR = '[ALTERAR] Situacao Pedido Error';

export class AlterarSituacaoPedido implements Action {
    readonly type = ALTERAR_SITUACAOPEDIDO;
  
    constructor(public payload: { idPedido: string, situacaoPedido: number }) {
    }
  }
  
  export class AlterarSituacaoPedidoSuccess implements Action {
    readonly type = ALTERAR_SITUACAOPEDIDO_SUCCESS;
  
    constructor(public payload: string) {
    }
  }
  
  export class AlterarSituacaoPedidoError implements Action {
    readonly type = ALTERAR_SITUACAOPEDIDO_ERROR;
  
    constructor(public payload: Error) {
    }
  }