import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {Router} from '@angular/router';
import {AppState} from '../app.state';
import { ObterClientes } from './store/clientes.actions';
import {
  obterCriarError, obterClientesError, isCreated
} from './store/clientes.reducers';
import { MessageService } from 'primeng/api';
import { NotificationMessageService } from '../shared/services/notification-message.service';

@Component({
  selector: 'app-clientes',
  template: `
    <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  constructor(private router: Router,
              private store: Store<AppState>,
              private messageService: MessageService,
              private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.store.dispatch(new ObterClientes(10));
    
    this.store.select(obterClientesError).subscribe((error) => this.showErroStore(error));

    this.store.select(isCreated).subscribe((done) => {
      this.showMsgCriadoERedirect(done, 'Cliente criado com sucesso');
    });

    this.store.select(obterCriarError).subscribe((error) => {
      this.showErrorAction(error, 'Erro ao criar cliente');
    });
  }
  
  showErroStore(error) {
    if (error) {
      const message = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(message)
    }
  }
  
  showMsgCriadoERedirect(done: boolean, message: string) {
    if (done) {
      this.notificationMessageService.mostrarMensagemSucesso(message)
      this.router.navigate(['/clientes']);
    }
  }
  
  showErrorAction(error, message: string) {
    if (error) {      
      this.notificationMessageService.mostrarMensagemErro(message)
    }
  }
}