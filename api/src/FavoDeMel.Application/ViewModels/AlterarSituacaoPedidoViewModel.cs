using FavoDeMel.Domain.Enums;
using System;

namespace FavoDeMel.Application.ViewModels
{
    public class AlterarSituacaoPedidoViewModel : ViewModel
    {
        public Guid IDPedido { get; set; }
        public int Situacao { get; set; }
    }
}
