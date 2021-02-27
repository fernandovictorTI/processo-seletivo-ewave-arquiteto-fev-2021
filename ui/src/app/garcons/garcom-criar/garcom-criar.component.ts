import {Component, OnInit} from '@angular/core';
import {Garcom} from '../shared/garcom';
import {AppState} from '../../app.state';
import {Store} from '@ngrx/store';
import { fromGarcomActions } from '../store/garcons.actions';
import {Router} from '@angular/router';

@Component({
  selector: 'app-garcom-criar',
  templateUrl: './garcom-criar.component.html',
  styleUrls: ['./garcom-criar.component.css']
})
export class GarcomCreateComponent implements OnInit {
  title = 'Criar um novo garcom';
  garcom: Garcom = new Garcom();

  constructor(private router: Router,
              private store: Store<AppState>) {
  }

  ngOnInit() {
  }

  voltar() {
    this.router.navigate(['/garcons']);
  }

  onSaveGarcom() {
    this.store.dispatch(fromGarcomActions.AdicionarGarcom( { entity: this.garcom } ));
  }

  limparCampos() {
    this.garcom.nome = "";
    this.garcom.telefone = "";
  }
}