import {NgModule} from '@angular/core';
import {cozinhasRoutedComponents, CozinhaRoutingModule} from './cozinha-routing.module';
import {SharedModule} from '../shared/shared.module';
import {StoreModule, ActionReducerMap} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {CozinhaEffects} from './store/cozinha.effects';
import * as cozinhaReducer from './store/cozinha.reducers';
import * as situacaoPedidoReducer from './store/situacaopedido.reducers';
import { SituacaoPedidoEffects } from './store/situacaopedido.effects';
import { PedidosService } from '../pedidos/shared/pedidos.service';

export const reducers: ActionReducerMap<any> = {
  'comandas-abertas': cozinhaReducer.reducer,
  'situacoespedido': situacaoPedidoReducer.reducer
};

@NgModule({
  imports: [
    SharedModule,
    CozinhaRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([CozinhaEffects, SituacaoPedidoEffects])
  ],
  declarations: [cozinhasRoutedComponents],
  providers: [PedidosService ]
})
export class CozinhaModule {
}