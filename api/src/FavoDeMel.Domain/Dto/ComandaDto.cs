﻿using FavoDeMel.Domain.Enums;
using System;
using System.Linq;

namespace FavoDeMel.Domain.Dto
{
    public class ComandaDto : DtoBase
    {
        public Guid IDComanda { get; init; }
        public int Numero { get; init; }
        public EnumSituacaoPedido Situacao { get; init; }
        public Guid IDPedido { get; init; }

        public bool IsAberta
        {
            get
            {
                if (Situacao == 0)
                    return true;

                return SituacaoPedido.SituacoesPermiteAberturaComanda.Any(c => c == Situacao);
            }
        }

        public ComandaDto(Guid idComanda, int numero, EnumSituacaoPedido situacao, Guid idPedido) =>
            (IDComanda, Numero, Situacao, IDPedido) = (idComanda, numero, situacao, idPedido);

        public ComandaDto(Guid idComanda, int numero) =>
            (IDComanda, Numero) = (idComanda, numero);

        public void Deconstruct(out Guid idComanda, out int numero, out EnumSituacaoPedido situacao, Guid idPedido, out bool isAberta)
            => (idComanda, numero, situacao, idPedido, isAberta) = (IDComanda, Numero, Situacao, IDPedido, IsAberta);
    }
}
