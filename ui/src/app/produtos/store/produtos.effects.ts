import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as produtoActions from './produtos.actions';
import {
  AdicionarProduto,
  AdicionarProdutoError,
  AdicionarProdutoSuccess,
  ObterProdutos,
  ObterProdutosError,
  ObterProdutosSuccess,
  ObterProduto,
  ObterProdutoError,
  ObterProdutoSuccess,
} from './produtos.actions';
import { Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { catchError, map, switchMap } from 'rxjs/operators';
import { ProdutosService } from 'src/app/shared/services/produtos.service';

@Injectable()
export class ProdutoEffects {
  constructor(private actions$: Actions,
    private svc: ProdutosService) {
  }

  @Effect()
  obterAllProdutos$: Observable<Action> = this.actions$.pipe(
    ofType(produtoActions.OBTER_PRODUTOS),
    map((action: ObterProdutos) => action.payload),
    switchMap((quantidade) => 
    this.svc.obter(quantidade).pipe(
      map(response => new ObterProdutosSuccess(response || [])),
      catchError((err) => [new ObterProdutosError(err.error)]))
    )    
  );

  @Effect()
  obterProduto$ = this.actions$.pipe(
    ofType(produtoActions.OBTER_PRODUTO),
    map((action: ObterProduto) => action.payload),
    switchMap(id => 
      this.svc.obterPorId(id).pipe(
        map(response => new ObterProdutoSuccess(response)),
        catchError((err) => [new ObterProdutoError(err.error)]))
      )
  );

  @Effect()
  createProduto$ = this.actions$.pipe(
    ofType(produtoActions.CRIAR_PRODUTO),
    map((action: AdicionarProduto) => action.payload),
    switchMap(newProduto =>
      this.svc.criar(newProduto).pipe(
        map((response) => new AdicionarProdutoSuccess(response.id)),
        catchError((err) => [new AdicionarProdutoError(err.error)]))
    )
  );
}