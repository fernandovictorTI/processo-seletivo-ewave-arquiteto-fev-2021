import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as produtosActions from './produtos.actions';
import { ProdutosService } from '../../shared/services/produtos.service';
import { map, switchMap, tap } from 'rxjs/operators';

@Injectable()
export class ProdutoEffects {
  constructor(private actions$: Actions,
    private svc: ProdutosService) {
  }

  obterAllGarcons$ = createEffect(
    () => this.actions$.pipe(
      ofType(produtosActions.ObterProdutos),
      map((action) => action),
      switchMap(({ quantidade }) => this.svc.obter(quantidade).pipe(
        map((response: any) => {
          return produtosActions.ObterProdutosSuccess({
            data: response
          });
        })
      ))
    )
  );

  obterProduto$ = createEffect(() => this.actions$.pipe(
    ofType(produtosActions.ObterProduto),
    switchMap(({ id }) => this.svc.obterPorId(id).pipe(
      map((response: any) => {
        return produtosActions.ObterProdutoSuccess({
          entity: response
        });
      })
    )),
    tap(error => this.handleErrors(error))
  ),
    { dispatch: false });

  createProduto$ = createEffect(
    () => this.actions$.pipe(
      ofType(produtosActions.AdicionarProduto),
      map((action) => action),
      switchMap(({ entity }) => this.svc.criar(entity).pipe(
        map((response) => {
          return produtosActions.AdicionarProdutoSuccess({
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