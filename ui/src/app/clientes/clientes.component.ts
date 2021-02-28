import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { isCreated } from './store/clientes.selector';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import {
  fromClienteActions
} from './store/clientes.actions';
import { ClienteState } from './store/clientes.reducers';

@Component({
  selector: 'app-clientes',
  template: `
    <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit, OnDestroy {

  private isCreatedCliente$;
  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(private router: Router,
    private store: Store<ClienteState>,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {

    this.store.dispatch(fromClienteActions.ObterClientes({ quantidade: 100 }));

    this.isCreatedCliente$ = this.store.select(isCreated);

    this.isCreatedCliente$
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((done) => {
        this.showMsgCriadoERedirect(done, 'Cliente criado com sucesso');
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