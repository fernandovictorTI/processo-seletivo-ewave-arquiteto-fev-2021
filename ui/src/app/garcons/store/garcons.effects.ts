import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as garconsActions from './garcons.actions';
import { of } from 'rxjs';
import { GarconsService } from '../../shared/services/garcons.service';
import { catchError, map, mergeMap, switchMap } from 'rxjs/operators';

@Injectable()
export class GarconsEffects {
  constructor(private actions$: Actions,
    private svc: GarconsService) {
  }

  obterAllGarcons$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.ObterGarcons),
    switchMap(() => this.svc.obter(10).pipe(
      map(response => garconsActions.ObterGarconsSuccess({
        data: response
      })),
      catchError((error) => of(
        garconsActions.ObterGarconsError({
          error
        })
      )))
    )
  ));

  obterGarcom$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.ObterGarcom),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return garconsActions.ObterGarcomSuccess({
          garcom: response
        });
      }),
      catchError(error => {
        console.log('Nao entra aqui mesmo');
        return of(
          garconsActions.ObterGarconsError({ error })
        )
      })
    ))
  ));

  createGarcom$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.AdicionarGarcom),
    map((action) => action.entity),
    switchMap(entity =>
      this.svc.criar(entity).pipe(
        map((response) => garconsActions.AdicionarGarcomSuccess({
          entity: response
        })),
        catchError(({ error: { errors } }) => [garconsActions.AdicionarGarcomError({
          error: errors
        })]))
    )
  ));
}