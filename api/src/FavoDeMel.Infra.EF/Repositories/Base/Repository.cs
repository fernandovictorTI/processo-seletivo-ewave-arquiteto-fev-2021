using FavoDeMel.Domain.Repositories.Base;
using FavoDeMel.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using PacoEvento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using FavoDeMel.Domain.Dto;
using AutoMapper;

namespace FavoDeMel.Infra.EF.Data.Repositories.Base
{
    public class Repository<TEntity, TDto> : IRepository<TEntity, TDto>
        where TEntity : Entity
        where TDto : DtoBase
    {
        protected readonly FavoDeMelContext Db;
        private readonly IMapper _mapper;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(
            FavoDeMelContext context,
            IMapper mapper)
        {
            Db = context;
            _mapper = mapper;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TDto GetById(Guid id)
        {
            return _mapper.Map<TDto>(DbSet.Find(id));
        }

        public virtual TEntity GetEntityById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Filter(Func<TEntity, bool> expresao)
        {
            return DbSet.Where(expresao);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
