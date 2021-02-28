import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as cozinhaActions from './cozinha.actions';
import { map, switchMap } from 'rxjs/operators';
import { ComandasService } from 'src/app/shared/services/comandas.service';
import { PedidosService } from 'src/app/shared/services/pedidos.service';

@Injectable()
export class CozinhaEffects {
  constructor(private actions$: Actions,
    private pedidosService: PedidosService,
    private svc: ComandasService) {
  }

  obterAllCozinha$ = createEffect(
    () => this.actions$.pipe(
      ofType(cozinhaActions.ObterComandasAbertas),
      switchMap(() => this.svc.obterComandasAbertas().pipe(
        map((response: any) => {
          return cozinhaActions.ObterComandasAbertasSuccess({
            data: response
          });
        })
      ))
    )
  );

  alterarSituacaoPedido$ = createEffect(
    () => this.actions$.pipe(
      ofType(cozinhaActions.AlterarSituacaoPedido),
      map((action) => action),
      switchMap(({ idPedido, situacaoPedido }) => this.pedidosService.alterarSituacaoPedido(idPedido, situacaoPedido).pipe(
        map((response) => {
          return cozinhaActions.AlterarSituacaoPedidoSuccess({
            msg: response
          });
        })
      ))
    )
  );

}