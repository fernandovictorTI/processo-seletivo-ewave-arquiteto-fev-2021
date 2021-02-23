using FavoDeMel.Domain.ValueObjects;
using FavoDeMel.Domain.Core.Entities;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Entities
{
    public class Comanda : Entity
    {
        public Comanda(ComandaVo numeroComanda)
        {
            NumeroComanda = numeroComanda;
            AddNotifications(numeroComanda);
        }

        public Comanda()
        {
        }

        public virtual ICollection<Pedido> Pedidos { get; private set; }
        public virtual ComandaVo NumeroComanda { get; private set; }
    }
}
