/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Core.DB.Mapper;

namespace Core.DB
{
    public class MapperFactory : IMapperFactory
    {
        public ICarMapper CreateCarMapper()
        {
            return new CarMapper();
        }

        public IUserMapper CreateUserMapper(ICarMapper carMapper)
        {
            return new UserMapper(carMapper);
        }
    }
}
