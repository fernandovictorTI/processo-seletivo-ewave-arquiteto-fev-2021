import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import * as criarPedidoActions from './criarpedido.actions';
import {
  AdicionarPedido,
  AdicionarPedidoSuccess,
  AdicionarPedidoError  
} from './criarpedido.actions';
import {PedidosService} from '../shared/pedidos.service';
import {catchError, map, switchMap} from 'rxjs/operators';

@Injectable()
export class CriarPedidoEffects {
  constructor(private actions$: Actions,
              private svc: PedidosService) {
  }

  @Effect()
  createPedido$ = this.actions$.pipe(
    ofType(criarPedidoActions.CRIAR_PEDIDO),
    map((action: AdicionarPedido) => action.payload),
    switchMap(newPedido =>  
      this.svc.criar(newPedido).pipe(
        map((response) => new AdicionarPedidoSuccess(newPedido)),
        catchError((err) => [new AdicionarPedidoError(err.error)]))
      )
  ); 
}