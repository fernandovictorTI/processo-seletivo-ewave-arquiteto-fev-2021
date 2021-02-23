import {NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import {StoreModule} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import { ComandasService } from './services/comandas.service';
import { GarconsService } from './services/garcons.service';
import { ProdutosService } from './services/produtos.service';
import { ClientesService } from './services/clientes.service';
import { TableModule } from "primeng/table";
import { ToastModule } from "primeng/toast";
import { CalendarModule } from "primeng/calendar";
import {MessageService} from 'primeng/api';
import { NotificationMessageService } from './services/notification-message.service';
import {FieldsetModule} from 'primeng/fieldset';

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
  providers: [ComandasService, GarconsService, ProdutosService, ClientesService, MessageService, NotificationMessageService],
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