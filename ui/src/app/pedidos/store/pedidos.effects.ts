import {Injectable} from '@angular/core';
import {Actions, createEffect, ofType} from '@ngrx/effects';
import * as pedidoActions from './pedidos.actions';
import {
  ObterPedidos,
  ObterPedidosError,
  ObterPedidosSuccess,
  ObterPedido,
  ObterPedidoError,
  ObterPedidoSuccess
} from './pedidos.actions';
import {Observable} from 'rxjs';
import {Action} from '@ngrx/store';
import {PedidosService} from '../shared/pedidos.service';
import {catchError, map, switchMap} from 'rxjs/operators';

@Injectable()
export class PedidoEffects {
  constructor(private actions$: Actions,
              private svc: PedidosService) {
  }
  
  obterAllPedidos$: Observable<Action> = createEffect(() => this.actions$.pipe(
    ofType(pedidoActions.OBTER_PEDIDOS),
    map((action: ObterPedidos) => action.payload),
    switchMap((quantidade) => 
      this.svc.obter(quantidade).pipe(
        map(response => new ObterPedidosSuccess(response)),
        catchError((err) => [new ObterPedidosError(err.error)])
      )
      )    
  ));

  obterPedido$ = createEffect(() => this.actions$.pipe(
    ofType(pedidoActions.OBTER_PEDIDO),
    map((action: ObterPedido) => action.payload),
    switchMap(id => 
      this.svc.obterPorId(id).pipe(
        map(response => new ObterPedidoSuccess(response)),
        catchError((err) => [new ObterPedidoError(err.error)]))
    )
  ));
}