import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as garconsActions from './garcons.actions';
import * as logsActions from '../../shared/store/logs.actions'
import { of } from 'rxjs';
import { GarconsService } from '../../shared/services/garcons.service';
import { catchError, map, mergeMap, switchMap } from 'rxjs/operators';
import { createAction } from '@ngrx/store';

export const noAction = createAction('State stay equal');

@Injectable()
export class GarconsEffects {
  constructor(private actions$: Actions,
    private svc: GarconsService) {
  }

  obterAllGarcons$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.ObterGarcom),
    switchMap(({ id }) => this.svc.obter(10).pipe(
      map((response: any) => {
        return garconsActions.ObterGarconsSuccess({
          data: response
        });
      })
    ))
  ));

  obterGarcom$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.ObterGarcom),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return garconsActions.ObterGarcomSuccess({
          garcom: response
        });
      })
    )),
    catchError(error => this.handleErrors(error))
  ));

  createGarcom$ = createEffect(() => this.actions$.pipe(
    ofType(garconsActions.AdicionarGarcom),
    map((action) => action),
    switchMap(({ entity }) => this.svc.criar(entity).pipe(
      map((response) => {
        return garconsActions.AdicionarGarcomSuccess({
          entity: response
        });
      })
    )),
    switchMap(res => [
      logsActions.LogErros({ erro: "" }),
    ]),
    catchError(error => this.handleErrors(error))
  ));

  handleErrors(error) {
    return of(error);
  }
}