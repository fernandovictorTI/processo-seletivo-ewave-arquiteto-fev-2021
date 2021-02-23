import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {PedidosComponent} from './pedidos.component';
import {PedidoListComponent} from './pedido-list/pedido-list.component';
import {PedidoCreateComponent} from './pedido-criar/pedido-criar.component';
import { GerenciarProdutosComponent } from './gerenciar-produtos/gerenciar-produtos.component';

export const pedidosRoutes: Routes = [{
  path: '',
  component: PedidosComponent,
  children: [
    {path: '', component: PedidoListComponent},
    {path: 'criar/:idComanda', component: PedidoCreateComponent},
    {path: 'gerenciar/:idPedido', component: GerenciarProdutosComponent},
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(pedidosRoutes)
  ],
  exports: [RouterModule]
})
export class PedidosRoutingModule {
}

export const pedidosRoutedComponents = [
  PedidosComponent,
  PedidoListComponent,
  PedidoCreateComponent,
  GerenciarProdutosComponent
];