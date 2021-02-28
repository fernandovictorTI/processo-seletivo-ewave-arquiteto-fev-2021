import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as garconsActions from './garcons.actions';
import * as logsActions from '../../shared/store/logs/logs.actions'
import { of } from 'rxjs';
import { GarconsService } from '../../shared/services/garcons.service';
import { catchError, map, mergeMap, switchMap, tap } from 'rxjs/operators';
import { createAction } from '@ngrx/store';

export const noAction = createAction('State stay equal');

@Injectable()
export class GarconsEffects {
  constructor(private actions$: Actions,
    private svc: GarconsService) {
  }

  obterAllGarcons$ = createEffect(
    () => this.actions$.pipe(
      ofType(garconsActions.ObterGarcons),
      map((action) => action),
      switchMap(({ quantidade }) => this.svc.obter(quantidade).pipe(
        map((response: any) => {
          return garconsActions.ObterGarconsSuccess({
            data: response
          });
        })
      ))
    )
  );

  obterGarcom$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.ObterGarcom),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return garconsActions.ObterGarcomSuccess({
          garcom: response
        });
      })
    )),
    tap(error => this.handleErrors(error))
  ),
    { dispatch: false });

  createGarcom$ = createEffect(
    () => this.actions$.pipe(
      ofType(garconsActions.AdicionarGarcom),
      map((action) => action),
      switchMap(({ entity }) => this.svc.criar(entity).pipe(
        map((response) => {
          return garconsActions.AdicionarGarcomSuccess({
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