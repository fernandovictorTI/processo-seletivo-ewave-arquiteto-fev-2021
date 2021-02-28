import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Comanda } from '../shared/comanda';
import { Observable } from 'rxjs';
import { ComandaState } from '../store/comandas.reducers';
import { Router } from '@angular/router';
import { RxStompService } from '@stomp/ng2-stompjs';
import { fromComandaActions } from '../store/comandas.actions';
import { selectObterComandas } from '../store/comandas.selector';

@Component({
  selector: 'app-comanda-list',
  templateUrl: './comanda-list.component.html',
  styleUrls: ['./comanda-list.component.css']
})
export class ComandaListComponent implements OnInit {
  title = 'Comandas';
  comandas: Observable<Comanda[]>;

  constructor(
    private store: Store<ComandaState>,
    private router: Router,
    private rxStompService: RxStompService) {
  }

  ngOnInit() {
    this.comandas = this.store.select(selectObterComandas);

    this.rxStompService.watch('/exchange/queue-situacao-pedido-alterada').subscribe((message) => {
      this.store.dispatch(fromComandaActions.ObterComandas({ quantidade: 100 }));
    });
  }

  abrirComanda(idComanda) {
    this.router.navigate(['/pedidos/criar', idComanda]);
  }

  gerenciarComanda(idPedido) {
    this.router.navigate(['/pedidos/gerenciar', idPedido]);
  }
}
