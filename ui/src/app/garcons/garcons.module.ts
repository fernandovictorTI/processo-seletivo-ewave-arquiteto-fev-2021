import { NgModule } from '@angular/core';
import { garconsRoutedComponents, GarconsRoutingModule } from './garcons-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    GarconsRoutingModule
  ],
  declarations: [garconsRoutedComponents],
  providers: []
})
export class GarconsModule {
}