using MediatR;

namespace FavoDeMel.Domain.Core.Querys
{
    public abstract class IQuery<T> : IRequest<T>
    {
    }
}
