import { createAction, props } from '@ngrx/store';
import { Cliente } from '../shared/cliente';

export enum ClienteActionTypes {
  OBTER_GARCONS = '[ALL] Clientes',
  OBTER_GARCONS_SUCCESS = '[ALL] Clientes Success',
  OBTER_CLIENTE = '[GET] Cliente',
  OBTER_CLIENTE_SUCCESS = '[GET] Clientes Success',
  CRIAR_CLIENTE = '[CRIAR] Cliente',
  CRIAR_CLIENTE_SUCCESS = '[CRIAR] Cliente Success',
}

export const ObterClientes = createAction(
  ClienteActionTypes.OBTER_GARCONS,
  props<{ quantidade: number }>()
);

export const ObterClientesSuccess = createAction(
  ClienteActionTypes.OBTER_GARCONS_SUCCESS,
  props<{ data: Cliente[] }>()
);

export const ObterCliente = createAction(
  ClienteActionTypes.OBTER_CLIENTE,
  props<{ id: string }>()
);

export const ObterClienteSuccess = createAction(
  ClienteActionTypes.OBTER_CLIENTE_SUCCESS,
  props<{ cliente: Cliente }>()
);

export const AdicionarCliente = createAction(
  ClienteActionTypes.CRIAR_CLIENTE,
  props<{ entity: Cliente }>()
);

export const AdicionarClienteSuccess = createAction(
  ClienteActionTypes.CRIAR_CLIENTE_SUCCESS,
  props<{ entity: Cliente }>()
);

export const fromClienteActions = {
  ObterClientes,
  ObterClientesSuccess,
  ObterCliente,
  ObterClienteSuccess,
  AdicionarCliente,
  AdicionarClienteSuccess
};
