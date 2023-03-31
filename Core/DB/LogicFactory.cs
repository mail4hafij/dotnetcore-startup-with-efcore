/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

using Core.DB.Logic;

namespace Core.DB
{
    public class LogicFactory : ILogicFactory
    {
        public IUserLogic CreateUserLogic(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork)
        {
            return new UserLogic(repositoryFactory, unitOfWork);
        }
    }
}
