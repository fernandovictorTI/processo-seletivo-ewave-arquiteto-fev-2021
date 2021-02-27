import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as situacaoPedidoActions from './situacaopedido.actions';
import { catchError, map, switchMap } from 'rxjs/operators';
import { AlterarSituacaoPedido, AlterarSituacaoPedidoSuccess, AlterarSituacaoPedidoError } from './situacaopedido.actions';
import { PedidosService } from 'src/app/shared/services/pedidos.service';

@Injectable()
export class SituacaoPedidoEffects {
  constructor(
    private actions$: Actions,
    private svc: PedidosService) {
  }

  alterarSituacaoPedido$ = createEffect(() => this.actions$.pipe(
    ofType(situacaoPedidoActions.ALTERAR_SITUACAOPEDIDO),
    map((action: AlterarSituacaoPedido) => action.payload),
    switchMap(payload =>
      this.svc.alterarSituacaoPedido(payload.idPedido, payload.situacaoPedido).pipe(
        map(() => new AlterarSituacaoPedidoSuccess(payload.idPedido)),
        catchError((err) => [new AlterarSituacaoPedidoError(err.error)]))
    )
  ));
}