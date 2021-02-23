using System;

namespace FavoDeMel.Domain.Dto
{
    public class ClienteDto : DtoBase
    {
        public Guid IDCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
