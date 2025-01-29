using Common.Contract.Messaging;
using Core.DB;
using Core.LIB;

namespace Core.Handler.Car
{
    public class AddCarHandler : RequestHandler<AddCarReq, AddCarResp>
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public AddCarHandler(IRepositoryFactory repositoryFactory,
            IUnitOfWorkFactory unitOfWorkFactory, IResponseFactory responseFactory) : base(unitOfWorkFactory, responseFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public override AddCarResp Process(AddCarReq req)
        {
            try
            {
                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    var userRepo = _repositoryFactory.CreateUserRepository(unitOfWork);
                    var carRepo = _repositoryFactory.CreateCarRepository(unitOfWork);

                    var user = userRepo.GetUser(req.UserId);
                    carRepo.AddCar(user.UserId, req.Nameplate);
                    unitOfWork.Commit();

                    return new AddCarResp();
                }
            }
            catch (Exception ex)
            {
                return GetErrorResp(ex, "Something went wrong");
            }
        }
    }
}
