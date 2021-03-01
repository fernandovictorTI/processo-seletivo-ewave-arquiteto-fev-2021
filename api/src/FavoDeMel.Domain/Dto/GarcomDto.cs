using System;

namespace FavoDeMel.Domain.Dto
{
    public class GarcomDto : DtoBase
    {
        public Guid IDGarcom { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }

        public GarcomDto(Guid idGarcom, string nome, string telefone) =>
            (IDGarcom, Nome, Telefone) = (idGarcom, nome, telefone);

        public void Deconstruct(out Guid idGarcom, out string nome, out string telefone) =>
            (idGarcom, nome, telefone) = (IDGarcom, Nome, Telefone);
    }
}
