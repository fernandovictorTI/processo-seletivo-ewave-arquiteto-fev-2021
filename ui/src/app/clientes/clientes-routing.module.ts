import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ClientesComponent} from './clientes.component';
import {ClienteListComponent} from './cliente-list/cliente-list.component';
import {ClienteCreateComponent} from './cliente-criar/cliente-criar.component';

export const clientesRoutes: Routes = [{
  path: '',
  component: ClientesComponent,
  children: [
    {path: '', component: ClienteListComponent},
    {path: 'criar', component: ClienteCreateComponent}
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(clientesRoutes)
  ],
  exports: [RouterModule]
})
export class ClientesRoutingModule {
}

export const clientesRoutedComponents = [
  ClientesComponent,
  ClienteListComponent,
  ClienteCreateComponent,
];