import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as cozinhaActions from './cozinha.actions';
import {
  ObterComandasAbertas,
  ObterComandasAbertasError,
  ObterComandasAbertasSuccess
} from './cozinha.actions';
import { Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { catchError, map, switchMap } from 'rxjs/operators';
import { ComandasService } from 'src/app/shared/services/comandas.service';

@Injectable()
export class CozinhaEffects {
  constructor(private actions$: Actions,
    private svc: ComandasService) {
  }

  @Effect()
  obterAllCozinha$: Observable<Action> = this.actions$.pipe(
    ofType(cozinhaActions.OBTER_COMANDAS_ABERTAS),
    switchMap(() => this.svc.obterComandasAbertas().pipe(
      map(response => new ObterComandasAbertasSuccess(response || [])),
      catchError((err) => [new ObterComandasAbertasError(err.error)])
    ))
  );
}