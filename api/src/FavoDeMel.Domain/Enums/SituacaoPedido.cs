using System.Collections.Generic;

namespace FavoDeMel.Domain.Enums
{
    public enum EnumSituacaoPedido
    {
        Aberto = 1,
        EmPreparo = 2,
        Pronto = 3,
        Finalizado = 4,
        Cancelado = 5
    }

    public static class SituacaoPedido
    {
        public static List<EnumSituacaoPedido> SituacoesPermiteAberturaComanda =>
            new List<EnumSituacaoPedido>() { EnumSituacaoPedido.Finalizado, EnumSituacaoPedido.Cancelado };
    }
}
