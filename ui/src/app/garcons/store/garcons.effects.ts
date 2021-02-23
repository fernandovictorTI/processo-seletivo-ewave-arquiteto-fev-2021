import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as comandaActions from './garcons.actions';
import {
  AdicionarGarcom,
  AdicionarGarcomError,
  AdicionarGarcomSuccess,
  ObterGarcons,
  ObterGarconsError,
  ObterGarconsSuccess,
  ObterGarcom,
  ObterGarcomError,
  ObterGarcomSuccess,
} from './garcons.actions';
import { Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { GarconsService } from '../../shared/services/garcons.service';
import { catchError, map, switchMap } from 'rxjs/operators';

@Injectable()
export class GarconsEffects {
  constructor(private actions$: Actions,
    private svc: GarconsService) {
  }

  @Effect()
  obterAllGarcons$: Observable<Action> = this.actions$.pipe(
    ofType(comandaActions.OBTER_GARCONS),
    map((action: ObterGarcons) => action.payload),
    switchMap((quantidade) => this.svc.obter(quantidade).pipe(
      map(response => new ObterGarconsSuccess(response || [])),
      catchError((err) => [new ObterGarconsError(err.error)]))
    )
  );

  @Effect()
  obterGarcom$ = this.actions$.pipe(
    ofType(comandaActions.OBTER_GARCOM),
    map((action: ObterGarcom) => action.payload),
    switchMap(id => this.svc.obterPorId(id).pipe(
      map(response => new ObterGarcomSuccess(response)),
      catchError((err) => [new ObterGarcomError(err.error)])
    ))
  );

  @Effect()
  createGarcom$ = this.actions$.pipe(
    ofType(comandaActions.CRIAR_GARCOM),
    map((action: AdicionarGarcom) => action.payload),
    switchMap(newGarcom => this.svc.criar(newGarcom).pipe(
      map((response) => new AdicionarGarcomSuccess(response.id)),
      catchError((err) => [new AdicionarGarcomError(err.error)])
    ))
  );
}