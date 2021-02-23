import {NgModule} from '@angular/core';
import {PedidosService} from './shared/pedidos.service';
import {pedidosRoutedComponents, PedidosRoutingModule} from './pedidos-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {PedidoEffects} from './store/pedidos.effects';
import { ProdutoPedidoEffects } from './store/produtospedido.effects';
import * as pedidoReducer from './store/pedidos.reducers';
import * as produtosPedidoReducer from './store/produtospedido.reducers';
import * as criarPedidoReducer from './store/criarpedido.reducers';
import { CriarPedidoEffects } from './store/criarpedido.effects';

export const reducers: ActionReducerMap<any> = {
  pedidos: pedidoReducer.reducer,
  'produtospedido': produtosPedidoReducer.reducer,
  'criarpedido': criarPedidoReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    PedidosRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([PedidoEffects, ProdutoPedidoEffects, CriarPedidoEffects])
  ],
  declarations: [pedidosRoutedComponents],
  providers: [
    PedidosService
  ]
})
export class PedidosModule {
}