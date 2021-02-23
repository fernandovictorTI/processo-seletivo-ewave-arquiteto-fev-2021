import { Component, OnInit } from '@angular/core';
import { Pedido } from '../shared/pedido';
import { AppState } from '../../app.state';
import { Store } from '@ngrx/store';
import { ObterPedido } from '../store/pedidos.actions';
import { AdicionarProdutoPedido, RemoverProdutoPedido } from '../store/produtospedido.actions';
import { obterPedido } from '../store/pedidos.reducers';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Produto } from 'src/app/produtos/shared/produto';
import { ProdutosService } from 'src/app/shared/services/produtos.service';
import { NotificationMessageService } from 'src/app/shared/services/notification-message.service';
import { foiRemovidoProdutoPedidoError, foiRemovidoProdutoPedido } from '../store/produtospedido.reducers';

@Component({
  selector: 'app-gerenciar-produtos',
  templateUrl: './gerenciar-produtos.component.html',
  styleUrls: ['./gerenciar-produtos.component.css']
})
export class GerenciarProdutosComponent implements OnInit {
  title = 'Gerenciar pedido';

  quantidadeProdutoSelecionado = 0;
  produtoSelecionado: Produto;

  produtos: Observable<Produto[]>;
  pedido: Pedido;
  idPedido;

  constructor(private router: Router,
    private store: Store<AppState>,
    private produtoService: ProdutosService,
    private route: ActivatedRoute,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {

    this.store.select(foiRemovidoProdutoPedidoError).subscribe((error) => {
      if (error) {
        this.showErrorAction(error);
        this.store.dispatch(new ObterPedido(this.idPedido));
      }
    });

    this.store.select(foiRemovidoProdutoPedido).subscribe((done) => {
      if (done)
        this.store.dispatch(new ObterPedido(this.idPedido));
    });

    this.produtos = this.produtoService.obterLovs();

    this.store.select(obterPedido)
      .subscribe(ped => {
        if(ped)
          this.pedido = ped;
      });

    this.route
      .params
      .subscribe(params => {
        this.idPedido = params['idPedido'];

        if (!this.idPedido)
          this.router.navigate(['/comandas']);

        if (!this.pedido)
          this.store.dispatch(new ObterPedido(this.idPedido));
      });
  }

  voltar() {
    this.router.navigate(['/pedidos']);
  }

  adicionarProdutoBanco() {
    if (this.quantidadeProdutoSelecionado <= 0 || !this.produtoSelecionado) {
      this.showErroTela("Selecione produto e quantidade.");
      return;
    }

    if (this.pedido.produtos.some(prod => prod.idProduto == this.produtoSelecionado.id)) {
      this.showErroTela("Produto já adicionado.");
      return;
    }

    const produtoPedido = {
      idProduto: this.produtoSelecionado.id,
      quantidade: this.quantidadeProdutoSelecionado,
      nome: this.produtoSelecionado.nome,
      valor: this.produtoSelecionado.valor
    };

    this.store.dispatch(new AdicionarProdutoPedido({ idPedido: this.pedido.id, ProdutoPedido: produtoPedido }));

    this.produtoSelecionado = null;
    this.quantidadeProdutoSelecionado = 0;
  }

  removerProdutoBanco(produto) {
    this.store.dispatch(new RemoverProdutoPedido({ idPedido: this.pedido.id, idProdutoPedido: produto.idProdutoPedido }));
  }

  showErroTela(erro) {
    this.notificationMessageService.mostrarMensagemErro(erro);
  }

  showErrorAction(error) {
    if (error) {
      const msgErro = error.map(erro => erro.message).join(', ');
      this.notificationMessageService.mostrarMensagemErro(msgErro);
    }
  }
}