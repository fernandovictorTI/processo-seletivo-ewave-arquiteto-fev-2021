import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as comandasActions from './comandas.actions';
import { ComandasService } from '../../shared/services/comandas.service';
import { map, switchMap, tap } from 'rxjs/operators';

@Injectable()
export class ComandaEffects {
  constructor(private actions$: Actions,
    private svc: ComandasService) {
  }

  obterAllComandas$ = createEffect(
    () => this.actions$.pipe(
      ofType(comandasActions.ObterComandas),
      map((action) => action),
      switchMap(({ quantidade }) => this.svc.obter(quantidade).pipe(
        map((response: any) => {
          return comandasActions.ObterComandasSuccess({
            data: response
          });
        })
      ))
    )
  );

  obterComanda$ = createEffect(() => this.actions$.pipe(
    ofType(comandasActions.ObterComanda),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return comandasActions.ObterComandaSuccess({
          comanda: response
        });
      })
    )),
    tap(error => this.handleErrors(error))
  ),
    { dispatch: false });

  createComanda$ = createEffect(
    () => this.actions$.pipe(
      ofType(comandasActions.AdicionarComanda),
      map((action) => action),
      switchMap(({ entity }) => this.svc.criar(entity).pipe(
        map((response) => {
          return comandasActions.AdicionarComandaSuccess({
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