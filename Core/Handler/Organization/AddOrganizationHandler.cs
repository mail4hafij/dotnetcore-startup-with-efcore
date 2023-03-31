using Common.Contract.Messaging;
using Core.DB;
using Core.LIB;

namespace Core.Handler.Landlord
{
    public class AddOrganizationHandler : RequestHandler<AddOrganizationReq, AddOrganizationResp>
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public AddOrganizationHandler(IRepositoryFactory repositoryFactory,
            IUnitOfWorkFactory unitOfWorkFactory, IResponseFactory responseFactory) : base(unitOfWorkFactory, responseFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public override AddOrganizationResp Process(AddOrganizationReq req)
        {
            try
            {
                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    var userRepo = _repositoryFactory.CreateUserRepository(unitOfWork);
                    var orgRepo = _repositoryFactory.CreateOrganizationRepository(unitOfWork);

                    var user = userRepo.GetUser(req.UserId);
                    orgRepo.AddOrganization(user.UserId, req.OrganizationName);
                    unitOfWork.Commit();

                    return new AddOrganizationResp();
                }
            }
            catch (Exception ex)
            {
                return GetErrorResp(ex, "Something went wrong");
            }
        }
    }
}
