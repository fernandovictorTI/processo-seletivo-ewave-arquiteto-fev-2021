import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as comandaActions from './comandas.actions';
import {
  AdicionarComanda,
  AdicionarComandaError,
  AdicionarComandaSuccess,
  ObterComandas,
  ObterComandasError,
  ObterComandasSuccess,
  ObterComanda,
  ObterComandaError,
  ObterComandaSuccess,
} from './comandas.actions';
import { Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { ComandasService } from '../../shared/services/comandas.service';
import { catchError, map, switchMap } from 'rxjs/operators';

@Injectable()
export class ComandaEffects {
  constructor(private actions$: Actions,
    private svc: ComandasService) {
  }

  @Effect()
  obterAllComandas$: Observable<Action> = this.actions$.pipe(
    ofType(comandaActions.OBTER_COMANDAS),
    map((action: ObterComandas) => action.payload),
    switchMap((quantidade) => this.svc.obter(quantidade).pipe(
      map(response => new ObterComandasSuccess(response || [])),
      catchError((err) => [new ObterComandasError(err.error)])
    ))
  );

  @Effect()
  obterComanda$ = this.actions$.pipe(
    ofType(comandaActions.OBTER_COMANDA),
    map((action: ObterComanda) => action.payload),
    switchMap(id => this.svc.obterPorId(id).pipe(
      map(response => new ObterComandaSuccess(response)),
      catchError((err) => [new ObterComandaError(err.error)])
    ))
  );

  @Effect()
  createComanda$ = this.actions$.pipe(
    ofType(comandaActions.CRIAR_COMANDA),
    map((action: AdicionarComanda) => action.payload),
    switchMap(newComanda => this.svc.criar(newComanda).pipe(
      map((response) => new AdicionarComandaSuccess(response.id)),
      catchError((err) => [new AdicionarComandaError(err.error)])
    ))
  );
}