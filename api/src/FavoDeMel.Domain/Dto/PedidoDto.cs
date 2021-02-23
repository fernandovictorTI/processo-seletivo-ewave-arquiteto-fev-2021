using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Dto
{
    public class PedidoDto : DtoBase
    {
        public PedidoDto()
        {
            Produtos = new List<ProdutoPedidoDto>();
        }

        public Guid IDPedido { get; set; }
        public Guid IDGarcom { get; set; }
        public string NomeGarcom { get; set; }
        public Guid IDCliente { get; set; }
        public string NomeCliente { get; set; }
        public Guid IDComanda { get; set; }
        public DateTime DataPedido { get; set; }
        public int NumeroComanda { get; set; }

        public List<ProdutoPedidoDto> Produtos { get; set; }
    }
}
