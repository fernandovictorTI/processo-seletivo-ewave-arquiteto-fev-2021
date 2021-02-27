import {NgModule} from '@angular/core';
import {garconsRoutedComponents, GarconsRoutingModule} from './garcons-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {GarconsEffects} from './store/garcons.effects';
// import { reducer } from './store/garcons.reducers';
import * as garconsReducer from './store/garcons.reducers';

export const reducers: ActionReducerMap<any> = {
  garcons: garconsReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    GarconsRoutingModule,
    StoreModule.forRoot({garcons: garconsReducer.reducer}),
    EffectsModule.forRoot([GarconsEffects])
  ],
  declarations: [garconsRoutedComponents],
  providers: []
})
export class GarconsModule {
}