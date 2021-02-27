import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as criarPedidoActions from './criarpedido.actions';
import {
  AdicionarPedido,
  AdicionarPedidoSuccess,
  AdicionarPedidoError
} from './criarpedido.actions';
import { catchError, map, switchMap } from 'rxjs/operators';
import { PedidosService } from 'src/app/shared/services/pedidos.service';

@Injectable()
export class CriarPedidoEffects {
  constructor(private actions$: Actions,
    private svc: PedidosService) {
  }

  createPedido$ = createEffect(() => this.actions$.pipe(
    ofType(criarPedidoActions.CRIAR_PEDIDO),
    map((action: AdicionarPedido) => action.payload),
    switchMap(newPedido =>
      this.svc.criar(newPedido).pipe(
        map((response) => new AdicionarPedidoSuccess(newPedido)),
        catchError((err) => [new AdicionarPedidoError(err.error)]))
    )
  ));
}