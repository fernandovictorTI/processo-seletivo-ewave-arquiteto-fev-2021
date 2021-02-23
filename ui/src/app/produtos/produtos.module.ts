import {NgModule} from '@angular/core';
import {produtosRoutedComponents, ProdutosRoutingModule} from './produtos-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {ProdutoEffects} from './store/produtos.effects';
import * as produtoReducer from './store/produtos.reducers';
import { ProdutosService } from '../shared/services/produtos.service';

export const reducers: ActionReducerMap<any> = {
  produtos: produtoReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    ProdutosRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([ProdutoEffects])
  ],
  declarations: [produtosRoutedComponents],
  providers: [
    ProdutosService
  ]
})
export class ProdutosModule {
}