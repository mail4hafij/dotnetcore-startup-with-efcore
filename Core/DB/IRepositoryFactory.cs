﻿/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Core.DB.Repo;

namespace Core.DB
{
    public interface IRepositoryFactory
    {
        public IOrganizationRepository CreateOrganizationRepository(IUnitOfWork unitOfWork);
        public IUserRepository CreateUserRepository(IUnitOfWork unitOfWork);
    }
}
