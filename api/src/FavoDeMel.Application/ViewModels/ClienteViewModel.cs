using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FavoDeMel.Application.ViewModels
{ 
    public class ClienteViewModel : ViewModel
    {
        [Required(ErrorMessage = "Nome é requerido")]
        [MinLength(3)]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
