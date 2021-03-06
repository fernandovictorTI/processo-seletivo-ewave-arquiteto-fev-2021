
export class Pedido {
  constructor() {
    this.produtos = [];
  }

  id: string;
  idGarcom: string;
  nomeGarcom: string;
  idComanda: string;
  numeroComanda: number;
  idCliente: string;
  nomeCliente: string;
  produtos: ProdutoPedido[];
}

export class ProdutoPedido {
  idProduto: string;
  nome: string;
  quantidade: number;
  valor: number
}