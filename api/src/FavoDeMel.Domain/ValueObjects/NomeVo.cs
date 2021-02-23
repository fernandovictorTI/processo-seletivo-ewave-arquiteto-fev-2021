using FavoDeMel.Domain.Core.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace FavoDeMel.Domain.ValueObjects
{
    public class NomeVo : ValueObject
    {
        public NomeVo(string nome)
        {
            Nome = nome;

            AddNotifications(
                new Contract<string>()
                .Requires()
                .IsGreaterThan(nome, 255, "Nome", "Nome deve ter menos de 255 caracteres.")
                .IsLowerThan(nome, 3, "Nome", "Nome deve ter mais de 3 caracteres.")
                );
        }

        public string Nome { get; private set; }
    }
}
