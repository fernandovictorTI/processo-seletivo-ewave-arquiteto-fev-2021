using System;

namespace FavoDeMel.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
