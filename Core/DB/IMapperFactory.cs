/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Core.DB.Mapper;

namespace Core.DB
{
    public interface IMapperFactory
    {
        public ICarMapper CreateCarMapper();
        public IUserMapper CreateUserMapper(ICarMapper carMapper);
    }
}
