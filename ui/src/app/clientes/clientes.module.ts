import {NgModule} from '@angular/core';
import {clientesRoutedComponents, ClientesRoutingModule} from './clientes-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {ClienteEffects} from './store/clientes.effects';
import * as clienteReducer from './store/clientes.reducers';

export const reducers: ActionReducerMap<any> = {
  clientes: clienteReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    ClientesRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([ClienteEffects])
  ],
  declarations: [clientesRoutedComponents],
  providers: []
})
export class ClientesModule {
}