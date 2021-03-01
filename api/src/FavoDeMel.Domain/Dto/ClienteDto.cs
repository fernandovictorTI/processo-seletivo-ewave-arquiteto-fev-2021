using System;

namespace FavoDeMel.Domain.Dto
{
    public class ClienteDto : DtoBase
    {
        public Guid IDCliente { get; init; }
        public string Nome { get; init; }
        public DateTime DataCriacao { get; init; }

        public ClienteDto(Guid idCliente, string nome, DateTime dataCriacao) =>
            (IDCliente, Nome, DataCriacao) = (idCliente, nome, dataCriacao);

        public void Deconstruct(out Guid idCliente, out string nome, out DateTime dataCriacao)
            => (idCliente, nome, dataCriacao) = (IDCliente, Nome, DataCriacao);
    }
}
