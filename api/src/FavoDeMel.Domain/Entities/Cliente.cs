using FavoDeMel.Domain.ValueObjects;
using FavoDeMel.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace FavoDeMel.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente() { }

        public Cliente(
            NomeVo nome)
        {
            Nome = nome;
            DataCriacao = DateTime.Now;   

            AddNotifications(nome);
        }

        public virtual NomeVo Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public virtual IEnumerable<Pedido> Pedidos { get; set; }
        

        public override string ToString()
        {
            return Nome.ToString();
        }
    }
}
