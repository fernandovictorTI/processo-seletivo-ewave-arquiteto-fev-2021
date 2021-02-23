using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FavoDeMel.Application.ViewModels
{
    public class PedidoViewModel : ViewModel
    {
        [Required]
        public Guid IDGarcom { get; set; }
        [Required]
        public Guid IDComanda { get; set; }
        [Required]
        public Guid IDCliente { get; set; }

        public List<ProdutoPedidoViewModel> Produtos { get; set; }
    }
}
