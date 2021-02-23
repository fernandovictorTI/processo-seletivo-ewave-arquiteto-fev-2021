import {Component, OnInit} from '@angular/core';
import {Comanda} from '../shared/comanda';
import {AppState} from '../../app.state';
import {Store} from '@ngrx/store';
import {AdicionarComanda} from '../store/comandas.actions';
import {Router} from '@angular/router';

@Component({
  selector: 'app-comanda-criar',
  templateUrl: './comanda-criar.component.html',
  styleUrls: ['./comanda-criar.component.css']
})
export class ComandaCreateComponent implements OnInit {
  title = 'Criar uma nova comanda';
  comanda: Comanda = new Comanda();

  constructor(private router: Router,
              private store: Store<AppState>) {
  }

  ngOnInit() {
  }

  voltar() {
    this.router.navigate(['/comandas']);
  }

  onSaveComanda() {
    this.store.dispatch(new AdicionarComanda(this.comanda));
  }

  limparCampos() {
    this.comanda.numero = 0;
  }
}