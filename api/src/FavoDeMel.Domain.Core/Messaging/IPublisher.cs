using System.Threading.Tasks;

namespace FavoDeMel.Domain.Core.Messaging
{
    public interface IPublisher
    {
        Task Publish<T>(T model) where T : IMessagin;
    }
}
