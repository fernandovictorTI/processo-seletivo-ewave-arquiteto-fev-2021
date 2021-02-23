import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {Router} from '@angular/router';
import {AppState} from '../app.state';
import { ObterGarcons } from './store/garcons.actions';
import {
  obterCriarError, obterGarconsError, isCreated
} from './store/garcons.reducers';
import { NotificationMessageService } from '../shared/services/notification-message.service';

@Component({
  selector: 'app-garcoms',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./garcons.component.css']
})
export class GarconsComponent implements OnInit {

  constructor(private router: Router,
              private store: Store<AppState>,
              private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.store.dispatch(new ObterGarcons(10));
    
    this.store.select(obterGarconsError).subscribe((error) => this.showErroStore(error));

    this.store.select(isCreated).subscribe((done) => {
      this.showMsgCriadoERedirect(done, 'Garcom criado com sucesso');
    });

    this.store.select(obterCriarError).subscribe((error) => {
      this.showErrorAction(error, 'Erro ao criar garcom');
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
      this.router.navigate(['/garcons']);
    }
  }
  
  showErrorAction(error, message: string) {
    if (error) {      
      const msgErro = error.map(erro => erro.message).join(', ');  
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}