import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as produtoPedidoActions from './produtospedido.actions';
import { map, switchMap } from 'rxjs/operators';
import { PedidosService } from 'src/app/shared/services/pedidos.service';

@Injectable()
export class ProdutoPedidoEffects {
  constructor(
    private actions$: Actions,
    private svc: PedidosService) {
  }

  adicionarProdutoPedido$ = createEffect(
    () => this.actions$.pipe(
      ofType(produtoPedidoActions.AdicionarProdutoPedido),
      map((action) => action),
      switchMap(({ idPedido, produtoPedido }) => this.svc.adicionarProdutoPedido(idPedido, produtoPedido).pipe(
        map((response) => {
          return produtoPedidoActions.AdicionarProdutoPedidoSuccess({
            msg: response
          });
        })
      ))
    )
  );

  removerProdutoPedido$ = createEffect(
    () => this.actions$.pipe(
      ofType(produtoPedidoActions.RemoverProdutoPedido),
      map((action) => action),
      switchMap(({ idPedido, idProdutoPedido }) => this.svc.removerProdutoPedido(idPedido, idProdutoPedido).pipe(
        map((response) => {
          return produtoPedidoActions.RemoverProdutoPedidoSuccess({
            msg: response
          });
        })
      ))
    )
  );
}