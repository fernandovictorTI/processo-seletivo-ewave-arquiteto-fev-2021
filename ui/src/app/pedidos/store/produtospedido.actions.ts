import { createAction, props } from '@ngrx/store';
import { ProdutoPedido } from '../shared/pedido';

export enum ProdutoPedidoActionTypes {
    CRIAR_PRODUTOPEDIDO = '[CRIAR] Produto Pedido',
    CRIAR_PRODUTOPEDIDO_SUCCESS = '[CRIAR] Produto Pedido Success',
    REMOVER_PRODUTOPEDIDO = '[REMOVER] Produto Pedido',
    REMOVER_PRODUTOPEDIDO_SUCCESS = '[REMOVER] Produto Pedido Success',
}

export const AdicionarProdutoPedido = createAction(
    ProdutoPedidoActionTypes.CRIAR_PRODUTOPEDIDO,
    props<{ idPedido: string, produtoPedido: ProdutoPedido }>()
);

export const AdicionarProdutoPedidoSuccess = createAction(
    ProdutoPedidoActionTypes.CRIAR_PRODUTOPEDIDO_SUCCESS,
    props<{ msg: string }>()
);

export const RemoverProdutoPedido = createAction(
    ProdutoPedidoActionTypes.REMOVER_PRODUTOPEDIDO,
    props<{ idPedido: string, idProdutoPedido: string }>()
);

export const RemoverProdutoPedidoSuccess = createAction(
    ProdutoPedidoActionTypes.REMOVER_PRODUTOPEDIDO_SUCCESS,
    props<{ msg: string }>()
);


export const fromProdutoPedidoActions = {
    AdicionarProdutoPedido,
    AdicionarProdutoPedidoSuccess,
    RemoverProdutoPedido,
    RemoverProdutoPedidoSuccess
};