using MediatR;

namespace FavoDeMel.Domain.Core.Querys
{
    public abstract class Query<T> : IRequest<T>
    {
    }
}
