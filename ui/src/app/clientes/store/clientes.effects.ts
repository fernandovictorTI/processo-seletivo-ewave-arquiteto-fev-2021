import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as clientesActions from './clientes.actions';
import { ClientesService } from '../../shared/services/clientes.service';
import { map, switchMap, tap } from 'rxjs/operators';

@Injectable()
export class ClienteEffects {
  constructor(private actions$: Actions,
    private svc: ClientesService) {
  }

  obterAllClientes$ = createEffect(
    () => this.actions$.pipe(
      ofType(clientesActions.ObterClientes),
      map((action) => action),
      switchMap(({ quantidade }) => this.svc.obter(quantidade).pipe(
        map((response: any) => {
          return clientesActions.ObterClientesSuccess({
            data: response
          });
        })
      ))
    )
  );

  obterCliente$ = createEffect(() => this.actions$.pipe(
    ofType(clientesActions.ObterCliente),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return clientesActions.ObterClienteSuccess({
          cliente: response
        });
      })
    )),
    tap(error => this.handleErrors(error))
  ),
    { dispatch: false });

  createCliente$ = createEffect(
    () => this.actions$.pipe(
      ofType(clientesActions.AdicionarCliente),
      map((action) => action),
      switchMap(({ entity }) => this.svc.criar(entity).pipe(
        map((response) => {
          return clientesActions.AdicionarClienteSuccess({
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