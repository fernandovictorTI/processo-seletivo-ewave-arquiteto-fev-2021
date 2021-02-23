import { Action } from '@ngrx/store';
import { ProdutoPedido } from '../shared/pedido';

export const CRIAR_PRODUTOPEDIDO = '[CRIAR] Produto Pedido';
export const CRIAR_PRODUTOPEDIDO_SUCCESS = '[CRIAR] Produto Pedido Success';
export const CRIAR_PRODUTOPEDIDO_ERROR = '[CRIAR] Produto Pedido Error';
export const REMOVER_PRODUTOPEDIDO = '[REMOVER] Produto Pedido';
export const REMOVER_PRODUTOPEDIDO_SUCCESS = '[REMOVER] Produto Pedido Success';
export const REMOVER_PRODUTOPEDIDO_ERROR = '[REMOVER] Produto Pedido Error';

export class AdicionarProdutoPedido implements Action {
    readonly type = CRIAR_PRODUTOPEDIDO;

    constructor(public payload: { idPedido: string, ProdutoPedido: ProdutoPedido }) {
    }
}

export class AdicionarProdutoPedidoSuccess implements Action {
    readonly type = CRIAR_PRODUTOPEDIDO_SUCCESS;

    constructor(public payload: string) {
    }
}

export class AdicionarProdutoPedidoError implements Action {
    readonly type = CRIAR_PRODUTOPEDIDO_ERROR;

    constructor(public payload: Error) {
    }
}

export class RemoverProdutoPedido implements Action {
    readonly type = REMOVER_PRODUTOPEDIDO;

    constructor(public payload: { idPedido: string, idProdutoPedido: string }) {
    }
}

export class RemoverProdutoPedidoSuccess implements Action {
    readonly type = REMOVER_PRODUTOPEDIDO_SUCCESS;

    constructor(public payload: string) {
    }
}

export class RemoverProdutoPedidoError implements Action {
    readonly type = REMOVER_PRODUTOPEDIDO_ERROR;

    constructor(public payload: Error) {
    }
}