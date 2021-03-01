using System;

namespace FavoDeMel.Domain.Dto
{
    public class GarcomDto : DtoBase
    {
        public Guid IDGarcom { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public GarcomDto() { }

        public GarcomDto(Guid idGarcom, string nome, string telefone) =>
            (IDGarcom, Nome, Telefone) = (idGarcom, nome, telefone);

        public void Deconstruct(out Guid idGarcom, out string nome, out string telefone) =>
            (idGarcom, nome, telefone) = (IDGarcom, Nome, Telefone);
    }
}
