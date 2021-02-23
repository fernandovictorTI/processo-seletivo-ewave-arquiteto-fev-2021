using FavoDeMel.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FavoDeMel.Domain.Repositories.Base
{
    public interface IRepository<TEntity, TDto> : IDisposable 
        where TEntity : class
        where TDto : DtoBase
    {
        void Add(TEntity obj);
        TDto GetById(Guid id);
        TEntity GetEntityById(Guid id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> expresao);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
