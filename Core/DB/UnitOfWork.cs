/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace Core.DB
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private bool _disposed;
        private bool _commitOrRollbackPerformed;

        public DataContext Context
        {
            get
            {
                if (_context == null)
                {
                    throw new Exception("UnitOfWork DataContext is null");
                }
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public UnitOfWork(IConfiguration configuration)
        {
            _context = new DataContext(configuration);
            _disposed = false;
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_commitOrRollbackPerformed)
            {
                return;
            }

            _context.SaveChanges();
            _context.Database.CommitTransaction();
            _commitOrRollbackPerformed = true;
        }

        public void Rollback()
        {
            if (_commitOrRollbackPerformed)
            {
                return;
            }

            _context.Database.RollbackTransaction();
            _commitOrRollbackPerformed = true;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (!_commitOrRollbackPerformed)
                {
                    Rollback();
                }
                _context.Dispose();
            }
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
