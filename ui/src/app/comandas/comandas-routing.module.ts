import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ComandasComponent} from './comandas.component';
import {ComandaListComponent} from './comanda-list/comanda-list.component';
import {ComandaCreateComponent} from './comanda-criar/comanda-criar.component';

export const comandasRoutes: Routes = [{
  path: '',
  component: ComandasComponent,
  children: [
    {path: '', component: ComandaListComponent},
    {path: 'criar', component: ComandaCreateComponent}
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(comandasRoutes)
  ],
  exports: [RouterModule]
})
export class ComandasRoutingModule {
}

export const comandasRoutedComponents = [
  ComandasComponent,
  ComandaListComponent,
  ComandaCreateComponent,
];