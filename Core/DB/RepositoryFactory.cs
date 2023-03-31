/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

using Core.DB.Repo;

namespace Core.DB
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IOrganizationRepository CreateOrganizationRepository(IUnitOfWork unitOfWork)
        {
            return new OrganizationRepository(unitOfWork);
        }

        public IUserRepository CreateUserRepository(IUnitOfWork unitOfWork)
        {
            return new UserRepository(unitOfWork);
        }
    }
}
