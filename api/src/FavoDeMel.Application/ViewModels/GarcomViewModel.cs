using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FavoDeMel.Application.ViewModels
{
    public class GarcomViewModel : ViewModel
    {
        [Required(ErrorMessage = "Nome é requerido")]
        [MinLength(3)]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é requerido")]        
        [MaxLength(15)]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
    }
}
