import {NgModule} from '@angular/core';
import {comandasRoutedComponents, ComandasRoutingModule} from './comandas-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {ComandaEffects} from './store/comandas.effects';
import * as comandaReducer from './store/comandas.reducers';

export const reducers: ActionReducerMap<any> = {
  comandas: comandaReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    ComandasRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([ComandaEffects])
  ],
  declarations: [comandasRoutedComponents],
  providers: [
  ]
})
export class ComandasModule {
}