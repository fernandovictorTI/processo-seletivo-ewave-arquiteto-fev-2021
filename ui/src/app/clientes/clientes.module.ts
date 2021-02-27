import { NgModule } from '@angular/core';
import { clientesRoutedComponents, ClientesRoutingModule } from './clientes-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ActionReducerMap } from '@ngrx/store';
import * as clienteReducer from './store/clientes.reducers';

export const reducers: ActionReducerMap<any> = {
  clientes: clienteReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    ClientesRoutingModule
  ],
  declarations: [clientesRoutedComponents],
  providers: []
})
export class ClientesModule {
}