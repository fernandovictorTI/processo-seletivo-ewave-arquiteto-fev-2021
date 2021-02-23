import {NgModule} from '@angular/core';
import {garconsRoutedComponents, GarconsRoutingModule} from './garcons-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {GarconsEffects} from './store/garcons.effects';
import * as comandaReducer from './store/garcons.reducers';

export const reducers: ActionReducerMap<any> = {
  garcons: comandaReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    GarconsRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([GarconsEffects])
  ],
  declarations: [garconsRoutedComponents],
  providers: []
})
export class GarconsModule {
}