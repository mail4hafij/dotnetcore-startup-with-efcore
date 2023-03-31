/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

namespace Core.DB
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork(bool useChangeTracking = true);
    }
}
