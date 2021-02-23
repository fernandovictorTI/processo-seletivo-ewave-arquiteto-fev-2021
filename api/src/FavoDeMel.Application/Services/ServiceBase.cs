using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Core.Entities;
using FavoDeMel.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Services
{
    public abstract class ServiceBase<Vm, Qm, Dto, Ent> 
        where Vm : ViewModel 
        where Qm : QueryModel
        where Dto : DtoBase
        where Ent : Entity
    {
        public abstract Task<Guid> Criar(Vm viewModel);
        public abstract Task<IEnumerable<Dto>> ObterListaPaginados(Qm queryModel);
        public abstract Task<Ent> Obter(Guid id);
    }
}
