/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

using Microsoft.EntityFrameworkCore.Storage;

namespace Core.DB
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext Context { get; set; }
        void Commit();
        void Rollback();
    }
}
