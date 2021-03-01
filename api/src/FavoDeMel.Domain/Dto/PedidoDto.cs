using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Dto
{
    public class PedidoDto : DtoBase
    {
        public Guid IDPedido { get; init; }
        public Guid IDGarcom { get; init; }
        public string NomeGarcom { get; init; }
        public Guid IDCliente { get; init; }
        public string NomeCliente { get; init; }
        public Guid IDComanda { get; init; }
        public DateTime DataPedido { get; init; }
        public int NumeroComanda { get; init; }

        public List<ProdutoPedidoDto> Produtos { get; init; }
        public PedidoDto() =>
            (Produtos) = (new List<ProdutoPedidoDto>());

        public PedidoDto(
            Guid iDPedido,
            Guid iDGarcom,
            string nomeGarcom,
            Guid iDCliente,
            string nomeCliente,
            Guid iDComanda,
            DateTime dataPedido,
            int numeroComanda) =>
            (IDPedido, IDGarcom, NomeGarcom, IDCliente, NomeCliente, IDComanda, DataPedido, NumeroComanda) =
            (iDPedido, iDGarcom, nomeGarcom, iDCliente, nomeCliente, iDComanda, dataPedido, numeroComanda);

        public PedidoDto(
            Guid iDPedido,
            Guid iDGarcom,
            string nomeGarcom,
            Guid iDCliente,
            string nomeCliente,
            Guid iDComanda,
            DateTime dataPedido,
            int numeroComanda,
            List<ProdutoPedidoDto> produtos) =>
            (IDPedido, IDGarcom, NomeGarcom, IDCliente, NomeCliente, IDComanda, DataPedido, NumeroComanda, Produtos) =
            (iDPedido, iDGarcom, nomeGarcom, iDCliente, nomeCliente, iDComanda, dataPedido, numeroComanda, produtos);
    }
}
