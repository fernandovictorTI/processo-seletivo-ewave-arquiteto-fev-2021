import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as clienteActions from './clientes.actions';
import {
  AdicionarCliente,
  AdicionarClienteError,
  AdicionarClienteSuccess,
  ObterClientes,
  ObterClientesError,
  ObterClientesSuccess,
  ObterCliente,
  ObterClienteError,
  ObterClienteSuccess,
} from './clientes.actions';
import { Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { catchError, map, switchMap } from 'rxjs/operators';
import { ClientesService } from 'src/app/shared/services/clientes.service';

@Injectable()
export class ClienteEffects {
  constructor(private actions$: Actions,
    private svc: ClientesService) {
  }

  @Effect()
  obterAllClientes$: Observable<Action> = this.actions$.pipe(
    ofType(clienteActions.OBTER_CLIENTES),
    map((action: ObterClientes) => action.payload),
    switchMap((quantidade) => this.svc.obter(quantidade).pipe(
      map(response => new ObterClientesSuccess(response || [])),
      catchError((err) => [new ObterClientesError(err.error)])
    ))
  );

  @Effect()
  obterCliente$ = this.actions$.pipe(
    ofType(clienteActions.OBTER_CLIENTE),
    map((action: ObterCliente) => action.payload),
    switchMap(id => this.svc.obterPorId(id).pipe(
      map(response => new ObterClienteSuccess(response)),
      catchError((err) => [new ObterClienteError(err.error)])
    ))
  );

  @Effect()
  createCliente$ = this.actions$.pipe(
    ofType(clienteActions.CRIAR_CLIENTE),
    map((action: AdicionarCliente) => action.payload),
    switchMap(newCliente => this.svc.criar(newCliente).pipe(
      map((response) => new AdicionarClienteSuccess(response.id)),
      catchError((err) => [new AdicionarClienteError(err.error)])
    ))
  );
}