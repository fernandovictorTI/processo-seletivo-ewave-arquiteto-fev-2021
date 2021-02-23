using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Core.Entities;
using FavoDeMel.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Interfaces
{
    public interface IServiceBase<Vm, Qm, Dto>
        where Vm : ViewModel
        where Qm : QueryModel
        where Dto : DtoBase
    {
        Task<Guid> Criar(Vm viewModel);
        Task<IEnumerable<Dto>> ObterListaPaginados(Qm queryModel);
        Task<Dto> Obter(Guid id);
    }
}
