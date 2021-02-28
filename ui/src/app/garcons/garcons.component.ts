import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { isCreated } from './store/garcons.selector';
import {
  fromGarcomActions
} from './store/garcons.actions';
import { NotificationMessageService } from '../shared/services/notification-message.service';
import { GarcomState } from './store/garcons.reducers';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-garcoms',
  template: `
  <p-toast [style]="{marginTop: '80px'}"></p-toast>
    <router-outlet></router-outlet>`,
  styleUrls: ['./garcons.component.css']
})
export class GarconsComponent implements OnInit, OnDestroy {

  private isCreatedGarcom$;
  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(private router: Router,
    private store: Store<GarcomState>,
    private notificationMessageService: NotificationMessageService) {
  }
  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {
    this.carregarListaGarcons();

    this.isCreatedGarcom$ = this.store.select(isCreated);

    this.isCreatedGarcom$
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((done) => {
        this.showMsgCriadoERedirect(done, 'Garcom criado com sucesso');
      });
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