using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FavoDeMel.Application.ViewModels
{
    public class ProdutoViewModel : ViewModel
    {
        [Required(ErrorMessage = "Nome é requerido")]
        [MinLength(3)]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Valor do produto é obrigatório")]
        public decimal Valor { get; set; }
    }
}
