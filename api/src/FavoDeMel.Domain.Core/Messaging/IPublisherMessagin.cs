using System.Threading.Tasks;

namespace FavoDeMel.Domain.Core.Messaging
{
    public interface IPublisherMessagin
    {
        Task Publish<T>(T model) where T : IMessagin;
    }
}
