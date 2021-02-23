import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {Router} from '@angular/router';
import {AppState} from '../app.state';
import { ObterProdutos } from './store/produtos.actions';
import {
  obterCriarError, obterProdutosError, isCreated
} from './store/produtos.reducers';
import { NotificationMessageService } from '../shared/services/notification-message.service';

@Component({
  selector: 'app-produtos',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  constructor(private router: Router,
              private store: Store<AppState>,
              private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.store.dispatch(new ObterProdutos(10));
    
    this.store.select(obterProdutosError).subscribe((error) => this.showErroStore(error));

    this.store.select(isCreated).subscribe((done) => {
      this.showMsgCriadoERedirect(done, 'Produto criado com sucesso');
    });

    this.store.select(obterCriarError).subscribe((error) => {
      this.showErrorAction(error, 'Erro ao criar produto');
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
      this.router.navigate(['/produtos']);
    }
  }
  
  showErrorAction(error, message: string) {
    if (error) {      
      const msgErro = error.map(erro => erro.message).join(', ');  
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}