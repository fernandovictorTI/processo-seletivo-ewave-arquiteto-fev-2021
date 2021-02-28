import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { AppState } from '../app.state';
import { isCreated } from './store/garcons.selector';
import {
  fromGarcomActions
} from './store/garcons.actions';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { GarcomState } from './store/garcons.reducers';

@Component({
  selector: 'app-garcoms',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./garcons.component.css']
})
export class GarconsComponent implements OnInit {

  isCreatedGarcom$;

  constructor(private router: Router,
    private store: Store<GarcomState>,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.carregarListaGarcons();

    // this.store.select(obterGarconsError).subscribe((error) => this.showErroStore(error));

    this.isCreatedGarcom$ = this.store.select(isCreated);

    this.isCreatedGarcom$.subscribe((done) => {
      this.showMsgCriadoERedirect(done, 'Garcom criado com sucesso');
    });
  }

  ngOnDestroy() {
    // this.isCreatedGarcom$.unsubscribe();
  }

  carregarListaGarcons() {
    this.store.dispatch(fromGarcomActions.ObterGarcons({ quantidade: 100 }));
  }

  showMsgCriadoERedirect(done: boolean, message: string) {
    if (done) {
      this.notificationMessageService.mostrarMensagemSucesso(message);
      this.router.navigate(['/garcons']);
    }
  }
}