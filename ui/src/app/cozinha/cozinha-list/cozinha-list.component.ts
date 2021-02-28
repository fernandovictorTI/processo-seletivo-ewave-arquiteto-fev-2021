import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Cozinha } from '../shared/cozinha';
import { Observable } from 'rxjs';
import { CozinhaState } from '../store/cozinha.reducers';
import { selectObterComandasAbertas } from '../store/cozinha.selector';
import { fromCozinhaActions } from '../store/cozinha.actions';

@Component({
  selector: 'app-cozinha-list',
  templateUrl: './cozinha-list.component.html',
  styleUrls: ['./cozinha-list.component.css']
})
export class CozinhaListComponent implements OnInit {
  title = 'Cozinha';
  comandasAbertas: Observable<Cozinha[]>;
  comandasNoAsync: Cozinha[];
  rowGroupMetadata;
  situacoes;

  constructor(
    private cozinhaStore: Store<CozinhaState>
  ) {

  }

  ngOnInit() {
    this.comandasAbertas = this.cozinhaStore.select(selectObterComandasAbertas);
    this.updateRowGroupMetaData();
    this.carregarSituacoes();
  }

  carregarSituacoes() {
    this.situacoes = [
      { label: 'Aberto', value: 1 },
      { label: 'EmPreparo', value: 2 },
      { label: 'Pronto', value: 3 },
      { label: 'Finalizado', value: 4 },
      { label: 'Cancelado', value: 5 }
    ]
  }

  alterarSituacaoPedido(idPedido: string, situacaoPedido: number) {
    this.cozinhaStore.dispatch(fromCozinhaActions.AlterarSituacaoPedido({ idPedido, situacaoPedido }));
  }

  onChangeSelectSituacao({ idPedido }, situacaoPedido) {
    this.alterarSituacaoPedido(idPedido, situacaoPedido);
  }

  updateRowGroupMetaData() {

    this.comandasAbertas.subscribe(comanda => {
      if (comanda) {
        this.comandasNoAsync = comanda;
        this.rowGroupMetadata = {};
        for (let i = 0; i < comanda.length; i++) {
          let rowData = comanda[i];
          let numero = rowData.numero;
          if (i == 0) {
            this.rowGroupMetadata[numero] = { index: 0, size: 1 };
          }
          else {
            let previousRowData = comanda[i - 1];
            let previousRowGroup = previousRowData.numero;
            if (numero === previousRowGroup)
              this.rowGroupMetadata[numero].size++;
            else
              this.rowGroupMetadata[numero] = { index: i, size: 1 };
          }
        }
      }
    });
  }
}