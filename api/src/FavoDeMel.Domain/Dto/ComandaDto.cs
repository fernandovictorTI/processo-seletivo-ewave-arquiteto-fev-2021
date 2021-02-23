using FavoDeMel.Domain.Enums;
using System;
using System.Linq;

namespace FavoDeMel.Domain.Dto
{
    public class ComandaDto : DtoBase
    {
        public Guid IDComanda { get; set; }
        public int Numero { get; set; }
        public EnumSituacaoPedido Situacao { get; set; }
        public Guid IDPedido { get; set; }
        public bool IsAberta
        {
            get
            {
                if (Situacao == 0)
                    return true;

                return SituacaoPedido.SituacoesPermiteAberturaComanda.Any(c => c == Situacao);
            }
        }
    }
}
