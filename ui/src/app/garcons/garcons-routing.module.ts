import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {GarconsComponent} from './garcons.component';
import {GarcomListComponent} from './garcom-list/garcom-list.component';
import {GarcomCreateComponent} from './garcom-criar/garcom-criar.component';

export const garconsRoutes: Routes = [{
  path: '',
  component: GarconsComponent,
  children: [
    {path: '', component: GarcomListComponent},
    {path: 'criar', component: GarcomCreateComponent}
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(garconsRoutes)
  ],
  exports: [RouterModule]
})
export class GarconsRoutingModule {
}

export const garconsRoutedComponents = [
  GarconsComponent,
  GarcomListComponent,
  GarcomCreateComponent,
];