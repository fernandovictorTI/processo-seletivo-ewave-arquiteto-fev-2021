import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ActionReducerMap, StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { TableModule } from "primeng/table";
import { ToastModule } from "primeng/toast";
import { CalendarModule } from "primeng/calendar";
import { MessageService } from 'primeng/api';
import { FieldsetModule } from 'primeng/fieldset';

import { NotificationMessageService } from './services/notification-message.service';
import { ComandasService } from './services/comandas.service';
import { GarconsService } from './services/garcons.service';
import { ProdutosService } from './services/produtos.service';
import { ClientesService } from './services/clientes.service';
import { PedidosService } from './services/pedidos.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    StoreModule,
    EffectsModule,
    TableModule,
    ToastModule,
    CalendarModule,
    FieldsetModule
  ],
  declarations: [],
  providers: [ComandasService, GarconsService, ProdutosService, ClientesService, MessageService, NotificationMessageService, PedidosService],
  exports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    TableModule,
    ToastModule,
    CalendarModule,
    FieldsetModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedModule {
}