/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

namespace Core.DB
{
    public abstract class LogicBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        public LogicBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
