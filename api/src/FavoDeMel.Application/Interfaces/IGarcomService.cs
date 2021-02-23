using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Dto;

namespace FavoDeMel.Application.Interfaces
{
    public interface IGarcomService : IServiceBase<GarcomViewModel, GarcomQueryModel, GarcomDto>
    {
    }
}
