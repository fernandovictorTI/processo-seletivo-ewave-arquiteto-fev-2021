import { NgModule } from '@angular/core';
import { comandasRoutedComponents, ComandasRoutingModule } from './comandas-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    ComandasRoutingModule
  ],
  declarations: [comandasRoutedComponents],
  providers: [
  ]
})
export class ComandasModule {
}