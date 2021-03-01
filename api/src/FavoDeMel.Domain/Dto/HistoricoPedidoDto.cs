using FavoDeMel.Domain.Enums;
using System;

namespace FavoDeMel.Domain.Dto
{
    public class HistoricoPedidoDto : DtoBase
    {
        public Guid IDHistoricoPedido { get; set; }
        public EnumSituacaoPedido Situacao { get; set; }
        public DateTime Data { get; set; }

        public HistoricoPedidoDto() { }

        public HistoricoPedidoDto(Guid idHistoricoPedido, EnumSituacaoPedido situacao, DateTime data) =>
            (IDHistoricoPedido, Situacao, Data) = (idHistoricoPedido, situacao, data);

        public void Deconstruct(out Guid idHistoricoPedido, out EnumSituacaoPedido situacao, out DateTime data) =>
            (idHistoricoPedido, situacao, data) = (IDHistoricoPedido, Situacao, Data);
    }
}
