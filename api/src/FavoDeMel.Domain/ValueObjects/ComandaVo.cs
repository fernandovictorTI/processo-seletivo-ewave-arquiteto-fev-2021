using FavoDeMel.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace FavoDeMel.Domain.ValueObjects
{
    public class ComandaVo : ValueObject
    {
        public ComandaVo(int numero)
        {
            Numero = numero;

            AddNotifications(
                new Contract<int>()
                .Requires()
                .IsGreaterOrEqualsThan(numero, 1, "ComandaVo.Numero", "O número da comanda deve ser maior que 1.")
                );
        }

        public int Numero { get; set; }
    }
}
