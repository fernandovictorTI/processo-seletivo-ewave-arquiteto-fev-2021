using FavoDeMel.Domain.UoW;
using PacoEvento.Infra.Data.Context;
using System;
using System.Data.Entity.Validation;

namespace FavoDeMel.Infra.Ef.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FavoDeMelContext _context;

        public UnitOfWork(FavoDeMelContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            using var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                _context.SaveChanges();
                dbContextTransaction.Commit();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                dbContextTransaction.Rollback();
                throw new DbEntityValidationException(ex.Message);
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
