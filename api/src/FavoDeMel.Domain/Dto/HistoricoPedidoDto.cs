using FavoDeMel.Domain.Enums;
using System;

namespace FavoDeMel.Domain.Dto
{
    public class HistoricoPedidoDto : DtoBase
    {
        public Guid IDHistoricoPedido { get; set; }
        public EnumSituacaoPedido Situacao { get; set; }
        public DateTime Data { get; set; }
    }
}
