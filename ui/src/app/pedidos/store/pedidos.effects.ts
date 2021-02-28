import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as pedidosActions from './pedidos.actions';
import { map, switchMap, tap } from 'rxjs/operators';
import { PedidosService } from 'src/app/shared/services/pedidos.service';

@Injectable()
export class PedidoEffects {
  constructor(private actions$: Actions,
    private svc: PedidosService) {
  }

  obterAllPedidos$ = createEffect(
    () => this.actions$.pipe(
      ofType(pedidosActions.ObterPedidos),
      map((action) => action),
      switchMap(({ quantidade }) => this.svc.obter(quantidade).pipe(
        map((response: any) => {
          return pedidosActions.ObterPedidosSuccess({
            data: response
          });
        })
      ))
    )
  );

  obterPedido$ = createEffect(() => this.actions$.pipe(
    ofType(pedidosActions.ObterPedido),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return pedidosActions.ObterPedidoSuccess({
          pedido: response
        });
      })
    ))
  ));

  createPedido$ = createEffect(
    () => this.actions$.pipe(
      ofType(pedidosActions.CriarPedido),
      map((action) => action),
      switchMap(({ entity }) => this.svc.criar(entity).pipe(
        map((response) => {
          return pedidosActions.CriarPedidoSuccess({
            entity: response
          });
        })
      ))
    )
  );

  handleErrors(error) {
    throw error;
  }
}