
import { foiCarregadoGarcons } from './store/garcons.selector';
import { fromGarcomActions } from './store/garcons.actions';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import { filter, first, tap } from 'rxjs/operators';

@Injectable()
export class GarcomResolver implements Resolve<Observable<any>> {

  constructor(private store: Store<any>) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
    return this.store
      .pipe(
        select(foiCarregadoGarcons),
        tap((loaded) => {
          if (!loaded) {
            this.store.dispatch(fromGarcomActions.ObterGarcons({ quantidade: 100 }));
          }

        }),
        filter(loaded => loaded),
        first()
      );
  }
}