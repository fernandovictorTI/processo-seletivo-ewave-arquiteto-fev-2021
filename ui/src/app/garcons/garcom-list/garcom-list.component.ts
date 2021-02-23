import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {AppState} from '../../app.state';
import {Garcom} from '../shared/garcom';
import {Observable} from 'rxjs';
import {obterAllGarcons} from '../store/garcons.reducers';

@Component({
  selector: 'app-garcom-list',
  templateUrl: './garcom-list.component.html',
  styleUrls: ['./garcom-list.component.css']
})
export class GarcomListComponent implements OnInit {
  title = 'Garcons';
  garcons: Observable<Garcom[]>;

  constructor(private store: Store<AppState>) {
  }

  ngOnInit() {
    this.garcons = this.store.select(obterAllGarcons);
  }
}