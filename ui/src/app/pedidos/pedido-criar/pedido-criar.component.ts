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

@Component({
  selector: 'app-pedido-criar',
  templateUrl: './pedido-criar.component.html',
  styleUrls: ['./pedido-criar.component.css']
})
export class PedidoCreateComponent implements OnInit {
  title = 'Criar um novo pedido';
  pedido: Pedido = new Pedido();

  quantidadeProdutoSelecionado = 0;
  produtoSelecionado: Produto;

  comandas: Observable<Comanda[]>;
  garcons: Observable<Garcom[]>;
  produtos: Observable<Produto[]>;
  clientes: Observable<Cliente[]>;

  constructor(private router: Router,
    private store: Store<AppState>,
    private comandaService: ComandasService,
    private garconService: GarconsService,
    private produtoService: ProdutosService,
    private clienteService: ClientesService,
    private route: ActivatedRoute,
    private notificationMessageService: NotificationMessageService) {
  }

  ngOnInit() {
    this.comandas = this.comandaService.obterLovs();
    this.garcons = this.garconService.obterLovs();
    this.produtos = this.produtoService.obterLovs();
    this.clientes = this.clienteService.obterLovs();

    this.pedido.produtos = [];

    this.route
      .params
      .subscribe(params => {
        const idComanda = params['idComanda'];

        if(!idComanda)
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

    if (this.quantidadeProdutoSelecionado <= 0 || !this.produtoSelecionado){    
      this.showErrorAction("Selecione produto e quantidade.");
      return;
    }

    if (this.pedido.produtos.some(prod => prod.idProduto == this.produtoSelecionado.id))
    {    
      this.showErrorAction("Produto já adicionado.");
      return;
    }

    this.pedido.produtos.push({
      idProduto: this.produtoSelecionado.id,
      quantidade: this.quantidadeProdutoSelecionado,
      nome: this.produtoSelecionado.nome,
      valor: this.produtoSelecionado.valor
    });

    this.produtoSelecionado = null;
    this.quantidadeProdutoSelecionado = 0;
  }

  removerProduto(produto) {
    this.pedido.produtos = this.pedido.produtos.filter(prod => prod.idProduto != produto.idProduto);
  }

  showErrorAction(message: string) {
      this.notificationMessageService.mostrarMensagemErro(message);
  }

  limparCampos() {
    this.pedido = new Pedido();
  }
}