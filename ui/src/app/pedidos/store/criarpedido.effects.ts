import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as criarPedidoActions from './criarpedido.actions';
import { map, switchMap } from 'rxjs/operators';
import { PedidosService } from 'src/app/shared/services/pedidos.service';

@Injectable()
export class CriarPedidoEffects {
  constructor(private actions$: Actions,
    private svc: PedidosService) {
  }

  createPedido$ = createEffect(
    () => this.actions$.pipe(
      ofType(criarPedidoActions.CriarPedido),
      map((action) => action),
      switchMap(({ entity }) => this.svc.criar(entity).pipe(
        map((response) => {
          return criarPedidoActions.CriarPedidoSuccess({
            entity: response
          });
        })
      ))
    )
  );
}