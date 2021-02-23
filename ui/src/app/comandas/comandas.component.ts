import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {Router} from '@angular/router';
import {AppState} from '../app.state';
import { ObterComandas } from './store/comandas.actions';
import {
  obterCriarError, obterComandasError, isCreated
} from './store/comandas.reducers';
import { NotificationMessageService } from '../shared/services/notification-message.service';

@Component({
  selector: 'app-comandas',
  template: `
    <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./comandas.component.css']
})
export class ComandasComponent implements OnInit {

  constructor(private router: Router,
              private store: Store<AppState>,
              private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.store.dispatch(new ObterComandas(1000));
    
    this.store.select(obterComandasError).subscribe((error) => this.showErroStore(error));

    this.store.select(isCreated).subscribe((done) => {
      if(done){
        this.store.dispatch(new ObterComandas(1000));
        this.showMsgCriadoERedirect(done, 'Comanda criado com sucesso');
      }
    });

    this.store.select(obterCriarError).subscribe((error) => {
      this.showErrorAction(error, 'Erro ao criar comanda');
    });
  }
  
  showErroStore(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
  
  showMsgCriadoERedirect(done: boolean, message: string) {
    if (done) {
      this.notificationMessageService.mostrarMensagemSucesso(message);
      this.router.navigate(['/comandas']);
    }
  }
  
  showErrorAction(error, message: string) {
    if (error) {    
      const msgErro = error.map(erro => erro.message).join(', ');  
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}