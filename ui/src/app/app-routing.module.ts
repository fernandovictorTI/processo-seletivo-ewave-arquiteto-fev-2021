import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {path: '', redirectTo: '/cozinha', pathMatch: 'full'},
  {
    path: 'cozinha',
    loadChildren: () => import('./cozinha/cozinha.module').then(m => m.CozinhaModule)
  },
  {
    path: 'clientes',
    loadChildren: () => import('./clientes/clientes.module').then(m => m.ClientesModule)
  },
  {
    path: 'comandas',
    loadChildren: () => import('./comandas/comandas.module').then(m => m.ComandasModule)
  },
  {
    path: 'garcons',
    loadChildren: () => import('./garcons/garcons.module').then(m => m.GarconsModule)
  },
  {
    path: 'produtos',
    loadChildren: () => import('./produtos/produtos.module').then(m => m.ProdutosModule)
  },
  {
    path: 'pedidos',
    loadChildren: () => import('./pedidos/pedidos.module').then(m => m.PedidosModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})

export class AppRoutingModule {

}