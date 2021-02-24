using FavoDeMel.Domain.ValueObjects;
using FavoDeMel.Domain.Core.Entities;
using Flunt.Validations;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Entities
{
    public class Garcom : Entity
    {
        public Garcom()
        {
        }

        public Garcom(NomeVo nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;

            AdicionarValidacoes();
        }

        private void AdicionarValidacoes()
        {
            AddNotifications(
               new Contract<object>()
               .Requires()
               .IsLowerOrEqualsThan(Telefone, 15, "Garcom.Telefone", "O telefone deve ter 15 caracteres.")
               .IsGreaterOrEqualsThan(Telefone, 3, "Garcom.Telefone", "O telefone deve ter mais de 3 caracteres.")
               .Join(Nome == null ? new NomeVo("") : Nome)
               );
        }

        public virtual NomeVo Nome { get; private set; }
        public string Telefone { get; private set; }

        public virtual IEnumerable<Pedido> Pedidos { get; set; }
    }
}
