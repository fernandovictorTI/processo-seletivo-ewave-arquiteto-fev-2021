using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FavoDeMel.Application.ViewModels
{
    public class ComandaViewModel : ViewModel
    {
        [Required(ErrorMessage = "Numero é requerido")]
        [DisplayName("Numero")]
        public int Numero { get; set; }
    }
}
