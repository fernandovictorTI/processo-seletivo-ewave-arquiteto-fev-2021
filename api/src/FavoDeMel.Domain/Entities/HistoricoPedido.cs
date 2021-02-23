using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Core.Entities;
using Flunt.Validations;
using System;

namespace FavoDeMel.Domain.Entities
{
    public class HistoricoPedido : Entity
    {
        public HistoricoPedido()
        {
        }

        public HistoricoPedido(
            EnumSituacaoPedido situacao,
            Guid idPedido)
        {
            var enumValido = Enum.IsDefined(typeof(EnumSituacaoPedido), situacao.ToString());

            AddNotifications(
                new Contract()
                .Requires()
                .IsTrue(enumValido, "HistoricoPedido.Situacao", "Situação e obrigatória.")
                );

            if (Valid)
            {
                Situacao = situacao;
                Data = DateTime.Now;
                IDPedido = idPedido;
            }
        }

        public virtual Pedido Pedido { get; private set; }
        public virtual Guid IDPedido { get; private set; }
        public EnumSituacaoPedido Situacao { get; private set; }
        public DateTime Data { get; private set; }
    }
}
