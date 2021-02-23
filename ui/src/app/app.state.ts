import * as fromClientes from './clientes/store/clientes.reducers';

export interface AppState {
  clientes: fromClientes.State;
}