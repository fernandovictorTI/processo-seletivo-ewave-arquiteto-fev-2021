import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ProdutosComponent} from './produtos.component';
import {ProdutoListComponent} from './produto-list/produto-list.component';
import {ProdutoCreateComponent} from './produto-criar/produto-criar.component';

export const produtosRoutes: Routes = [{
  path: '',
  component: ProdutosComponent,
  children: [
    {path: '', component: ProdutoListComponent},
    {path: 'criar', component: ProdutoCreateComponent}
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(produtosRoutes)
  ],
  exports: [RouterModule]
})
export class ProdutosRoutingModule {
}

export const produtosRoutedComponents = [
  ProdutosComponent,
  ProdutoListComponent,
  ProdutoCreateComponent,
];