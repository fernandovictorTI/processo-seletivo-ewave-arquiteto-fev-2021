import { Component, OnInit } from '@angular/core';
import { Pedido } from '../shared/pedido';
import { Store } from '@ngrx/store';
import { fromPedidoActions } from '../store/pedidos.actions';
import { fromProdutoPedidoActions } from '../store/produtospedido.actions';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Produto } from 'src/app/produtos/shared/produto';
import { ProdutosService } from 'src/app/shared/services/produtos.service';
import { NotificationMessageService } from 'src/app/shared/services/notification-message.service';
import { ProdutoPedidoState } from '../store/produtospedido.reducers';
import { FormBuilder, FormGroup } from '@angular/forms';
import { selectObterPedido } from '../store/pedidos.selector';
import { PedidoState } from '../store/pedidos.reducers';
import { isRemovedProdutoPedido, isCreatedProdutoPedido } from '../store/produtospedido.selector';

@Component({
  selector: 'app-gerenciar-produtos',
  templateUrl: './gerenciar-produtos.component.html',
  styleUrls: ['./gerenciar-produtos.component.css']
})
export class GerenciarProdutosComponent implements OnInit {
  title = 'Gerenciar pedido';

  frm: FormGroup;

  produtos: Observable<Produto[]>;
  pedido: Pedido;
  idPedido;

  constructor(private router: Router,
    private produtoPedidoStore: Store<ProdutoPedidoState>,
    private pedidoStore: Store<PedidoState>,
    private fb: FormBuilder,
    private produtoService: ProdutosService,
    private route: ActivatedRoute,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {

    this.iniciarFormulario();

    this.produtoPedidoStore.select(isRemovedProdutoPedido).subscribe((done) => {
      if (done)
        this.carregarPedido(this.idPedido);
    });

    this.produtoPedidoStore.select(isCreatedProdutoPedido).subscribe((done) => {
      if (done)
        this.carregarPedido(this.idPedido);
    });

    this.produtos = this.produtoService.obterLovs();

    this.pedidoStore.select(selectObterPedido)
      .subscribe(ped => {
        if (ped)
          this.pedido = ped;
      });

    this.route
      .params
      .subscribe(params => {
        this.idPedido = params['idPedido'];

        if (!this.idPedido)
          this.router.navigate(['/comandas']);

        if (!this.pedido)
          this.carregarPedido(this.idPedido);
      });
  }

  carregarPedido(idPedido) {
    this.pedidoStore.dispatch(fromPedidoActions.ObterPedido({ id: idPedido }));
  }

  voltar() {
    this.router.navigate(['/pedidos']);
  }

  adicionarProdutoBanco() {

    const { produtoSelecionado, quantidadeProdutoSelecionado } = this.frm.getRawValue();

    if (quantidadeProdutoSelecionado <= 0 || !produtoSelecionado) {
      this.notificationMessageService.mostrarMensagemErro("Selecione produto e quantidade.");
      return;
    }

    if (this.pedido.produtos.some(prod => prod.idProduto == produtoSelecionado.id)) {
      this.notificationMessageService.mostrarMensagemErro("Produto já adicionado.");
      return;
    }

    const produtoPedido = {
      idProduto: produtoSelecionado.id,
      quantidade: quantidadeProdutoSelecionado,
      nome: produtoSelecionado.nome,
      valor: produtoSelecionado.valor
    };

    this.produtoPedidoStore.dispatch(fromProdutoPedidoActions.AdicionarProdutoPedido({ idPedido: this.pedido.id, produtoPedido: produtoPedido }));

    this.iniciarFormulario();
  }

  iniciarFormulario() {
    this.frm = this.fb.group({
      quantidadeProdutoSelecionado: [],
      produtoSelecionado: []
    });
  }

  removerProdutoBanco(produto) {
    this.produtoPedidoStore.dispatch(fromProdutoPedidoActions.RemoverProdutoPedido({ idPedido: this.pedido.id, idProdutoPedido: produto.idProdutoPedido }));
  }
}