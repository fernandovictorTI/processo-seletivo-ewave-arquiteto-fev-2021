using System;

namespace FavoDeMel.Domain.Dto
{
    public class GarcomDto : DtoBase
    {
        public Guid IDGarcom { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
