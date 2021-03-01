using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Dto
{
    public class PedidoDto : DtoBase
    {
        public Guid IDPedido { get; set; }
        public Guid IDGarcom { get; set; }
        public string NomeGarcom { get; set; }
        public Guid IDCliente { get; set; }
        public string NomeCliente { get; set; }
        public Guid IDComanda { get; set; }
        public DateTime DataPedido { get; set; }
        public int NumeroComanda { get; set; }

        public List<ProdutoPedidoDto> Produtos { get; set; }
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
