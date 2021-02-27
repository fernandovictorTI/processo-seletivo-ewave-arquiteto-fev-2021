import { NgModule } from '@angular/core';
import { pedidosRoutedComponents, PedidosRoutingModule } from './pedidos-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    PedidosRoutingModule
  ],
  declarations: [pedidosRoutedComponents],
  providers: []
})
export class PedidosModule {
}