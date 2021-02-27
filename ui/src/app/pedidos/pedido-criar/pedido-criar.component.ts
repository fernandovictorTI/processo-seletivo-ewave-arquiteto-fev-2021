import { Component, OnInit } from '@angular/core';
import { Pedido } from '../shared/pedido';
import { AppState } from '../../app.state';
import { Store } from '@ngrx/store';
import { Router, ActivatedRoute } from '@angular/router';
import { ComandasService } from 'src/app/shared/services/comandas.service';
import { GarconsService } from 'src/app/shared/services/garcons.service';
import { Observable } from 'rxjs';
import { Comanda } from 'src/app/comandas/shared/comanda';
import { Garcom } from 'src/app/garcons/shared/garcom';
import { Produto } from 'src/app/produtos/shared/produto';
import { ProdutosService } from 'src/app/shared/services/produtos.service';
import { Cliente } from 'src/app/clientes/shared/cliente';
import { ClientesService } from 'src/app/shared/services/clientes.service';
import { NotificationMessageService } from 'src/app/shared/services/notification-message.service';
import { AdicionarPedido } from '../store/criarpedido.actions';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pedido-criar',
  templateUrl: './pedido-criar.component.html',
  styleUrls: ['./pedido-criar.component.css']
})
export class PedidoCreateComponent implements OnInit {
  frm: FormGroup;
  title = 'Criar um novo pedido';
  pedido: Pedido = new Pedido();

  quantidadeProdutoSelecionado = 0;
  produtoSelecionado: Produto;

  comandas: Observable<Comanda[]>;
  garcons: Observable<Garcom[]>;
  produtos: Observable<Produto[]>;
  clientes: Observable<Cliente[]>;

  constructor(private router: Router,
    private fb: FormBuilder,
    private store: Store<AppState>,
    private comandaService: ComandasService,
    private garconService: GarconsService,
    private produtoService: ProdutosService,
    private clienteService: ClientesService,
    private route: ActivatedRoute,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {

    this.iniciarFormulario();

    this.comandas = this.comandaService.obterLovs();
    this.garcons = this.garconService.obterLovs();
    this.produtos = this.produtoService.obterLovs();
    this.clientes = this.clienteService.obterLovs();

    this.pedido.produtos = [];

    this.route
      .params
      .subscribe(params => {
        const idComanda = params['idComanda'];

        if (!idComanda)
          this.router.navigate(['/comandas']);

        this.pedido.idComanda = idComanda;
      });
  }

  voltar() {
    this.router.navigate(['/pedidos']);
  }

  onSavePedido() {
    this.store.dispatch(new AdicionarPedido(this.pedido));
  }

  adicionarProduto() {

    const { produtoSelecionado, quantidadeProdutoSelecionado, idCliente, idGarcom } = this.frm.getRawValue();

    if (quantidadeProdutoSelecionado <= 0 || !produtoSelecionado) {
      this.showErrorAction("Selecione produto e quantidade.");
      return;
    }

    if (this.pedido.produtos.some(prod => prod.idProduto == produtoSelecionado.id)) {
      this.showErrorAction("Produto já adicionado.");
      return;
    }

    this.pedido.idCliente = idCliente;
    this.pedido.idGarcom = idGarcom;

    this.pedido.produtos.push({
      idProduto: produtoSelecionado.id,
      quantidade: quantidadeProdutoSelecionado,
      nome: produtoSelecionado.nome,
      valor: produtoSelecionado.valor
    });

    this.iniciarFormulario();
  }

  removerProduto(produto) {
    this.pedido.produtos = this.pedido.produtos.filter(prod => prod.idProduto != produto.idProduto);
  }

  showErrorAction(message: string) {
    this.notificationMessageService.mostrarMensagemErro(message);
  }

  iniciarFormulario() {
    this.frm = this.fb.group({
      produtoSelecionado: [],
      quantidadeProdutoSelecionado: [],
      idCliente: [],
      idGarcom: []
    });
  }

  limparCampos() {
    this.iniciarFormulario();
  }
}