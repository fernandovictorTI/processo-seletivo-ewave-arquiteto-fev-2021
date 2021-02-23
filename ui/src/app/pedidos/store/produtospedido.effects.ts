import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as produtoPedidoActions from './produtospedido.actions';
import {
  AdicionarProdutoPedido,
  AdicionarProdutoPedidoSuccess,
  AdicionarProdutoPedidoError,
  RemoverProdutoPedido,
  RemoverProdutoPedidoSuccess,
  RemoverProdutoPedidoError
} from './produtospedido.actions';
import * as pedidoActions from './pedidos.actions';
import { PedidosService } from '../shared/pedidos.service';
import { catchError, map, switchMap } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { ObterPedido } from './pedidos.actions';

@Injectable()
export class ProdutoPedidoEffects {
  constructor(
    private store: Store<AppState>,
    private actions$: Actions,
    private svc: PedidosService) {
  }

  @Effect()
  adicionarProdutoPedido$ = this.actions$.pipe(
    ofType(produtoPedidoActions.CRIAR_PRODUTOPEDIDO),
    map((action: AdicionarProdutoPedido) => action.payload),
    switchMap(payload =>
      this.svc.adicionarProdutoPedido(payload.idPedido, payload.ProdutoPedido).pipe(
        map(() => new AdicionarProdutoPedidoSuccess(payload.idPedido)),
        catchError((err) => [new AdicionarProdutoPedidoError(err.error)]))
    )
  );

  @Effect()
  removerProdutoPedido$ = this.actions$.pipe(
    ofType(produtoPedidoActions.REMOVER_PRODUTOPEDIDO),
    map((action: RemoverProdutoPedido) => action.payload),
    switchMap(payload =>
      this.svc.removerProdutoPedido(payload.idPedido, payload.idProdutoPedido).pipe(
        map((response) => new RemoverProdutoPedidoSuccess(payload.idPedido)),
        catchError((err) => [new RemoverProdutoPedidoError(err.error)]))
    )
  );
}