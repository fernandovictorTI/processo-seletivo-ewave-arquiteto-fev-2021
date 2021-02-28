import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, ErrorHandler, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { favoDeMelRxStompConfig } from './core/configs/favodemel-rx-stomp.config';
import { InjectableRxStompConfig, RxStompService, rxStompServiceFactory } from '@stomp/ng2-stompjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from 'src/environments/environment';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpErrorInterceptor } from './core/errors/http-error-interceptor';
import { GlobalErrorHandler } from './core/errors/global-error-handler';

import * as produtoReducer from './produtos/store/produtos.reducers';
import * as garconsReducer from './garcons/store/garcons.reducers';
import * as cozinhaReducer from './cozinha/store/cozinha.reducers';
import * as comandaReducer from './comandas/store/comandas.reducers';
import * as clienteReducer from './clientes/store/clientes.reducers';
import * as produtosPedidoReducer from './pedidos/store/produtospedido.reducers';
import * as criarPedidoReducer from './pedidos/store/criarpedido.reducers';
import * as pedidosReducer from './pedidos/store/pedidos.reducers';
import * as logsReducer from './shared/store/logs/logs.reducers';

import { ProdutoEffects } from './produtos/store/produtos.effects';
import { GarconsEffects } from './garcons/store/garcons.effects';
import { CozinhaEffects } from './cozinha/store/cozinha.effects';
import { ComandaEffects } from './comandas/store/comandas.effects';
import { ClienteEffects } from './clientes/store/clientes.effects';
import { PedidoEffects } from './pedidos/store/pedidos.effects';
import { ProdutoPedidoEffects } from './pedidos/store/produtospedido.effects';
import { CriarPedidoEffects } from './pedidos/store/criarpedido.effects';
import { ActionReducerMap, StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { NotificationMessageService } from './shared/services/notification-message.service';
import { MessageService } from 'primeng/api';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { CustomSerializer } from './shared/store/router/custom-serializer';

export const reducers: ActionReducerMap<any> = {
  produtos: produtoReducer.reducer,
  garcons: garconsReducer.reducer,
  'comandas-abertas': cozinhaReducer.reducer,
  comandas: comandaReducer.reducer,
  clientes: clienteReducer.reducer,
  pedidos: pedidosReducer.reducer,
  'produtospedido': produtosPedidoReducer.reducer,
  'criarpedido': criarPedidoReducer.reducer,
  'logs': logsReducer.reducer
};

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    AppRoutingModule,
    StoreDevtoolsModule.instrument({
      maxAge: 25
    }),
    StoreModule.forRoot(reducers, {
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true,
        strictStateSerializability: true,
        strictActionSerializability: false,
      },
    }),
    EffectsModule.forRoot([ProdutoEffects, GarconsEffects, CozinhaEffects, ComandaEffects, ClienteEffects, PedidoEffects, ProdutoPedidoEffects, CriarPedidoEffects]),
    StoreRouterConnectingModule.forRoot({ serializer: CustomSerializer }),
  ],
  providers: [
    {
      provide: InjectableRxStompConfig,
      useValue: favoDeMelRxStompConfig,
    },
    {
      provide: RxStompService,
      useFactory: rxStompServiceFactory,
      deps: [InjectableRxStompConfig]
    },
    // { provide: ErrorHandler, useClass: GlobalErrorHandler },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    , MessageService, NotificationMessageService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
}