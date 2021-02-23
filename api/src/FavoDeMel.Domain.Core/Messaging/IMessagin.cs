using System;

namespace FavoDeMel.Domain.Core.Messaging
{
    public interface IMessagin
    {
        string Key { get; }
        DateTime DataCriacao { get; }
    }
}
