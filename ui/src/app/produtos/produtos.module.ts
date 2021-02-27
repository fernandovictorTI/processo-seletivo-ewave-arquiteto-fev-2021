import { NgModule } from '@angular/core';
import { produtosRoutedComponents, ProdutosRoutingModule } from './produtos-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ActionReducerMap } from '@ngrx/store';
import * as produtoReducer from './store/produtos.reducers';
import { ProdutosService } from '../shared/services/produtos.service';

export const reducers: ActionReducerMap<any> = {
  produtos: produtoReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    ProdutosRoutingModule
  ],
  declarations: [produtosRoutedComponents],
  providers: [
    ProdutosService
  ]
})
export class ProdutosModule {
}