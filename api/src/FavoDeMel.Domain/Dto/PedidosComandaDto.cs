using FavoDeMel.Domain.Enums;
using System;

namespace FavoDeMel.Domain.Dto
{
    public class PedidosComandaDto
    {
        public Guid IDPedido { get; set; }
        public int Numero { get; set; }
        public Guid IDComanda { get; set; }
        public Guid IDProdutoPedido { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataPedido { get; set; }
        public Guid IDGarcom { get; set; }
        public string NomeGarcom { get; set; }
        public Guid IDCliente { get; set; }
        public string NomeCliente { get; set; }
        public EnumSituacaoPedido Situacao { get; set; }
        public string SituacaoDescription
        {
            get { return Situacao.ToString(); }
        }

        public PedidosComandaDto() { }
    }
}