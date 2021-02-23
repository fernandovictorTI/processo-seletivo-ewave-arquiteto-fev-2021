import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CozinhaComponent} from './cozinha.component';
import {CozinhaListComponent} from './cozinha-list/cozinha-list.component';

export const cozinhaRoutes: Routes = [{
  path: '',
  component: CozinhaComponent,
  children: [
    {path: '', component: CozinhaListComponent},
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(cozinhaRoutes)
  ],
  exports: [RouterModule]
})
export class CozinhaRoutingModule {
}

export const cozinhasRoutedComponents = [
  CozinhaComponent,
  CozinhaListComponent,
];