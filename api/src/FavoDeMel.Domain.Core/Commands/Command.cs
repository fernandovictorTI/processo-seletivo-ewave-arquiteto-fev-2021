using MediatR;

namespace FavoDeMel.Domain.Core.Commands
{
    public abstract class Command : IRequest<string>
    {
        protected Command()
        {
        }
    }
}
