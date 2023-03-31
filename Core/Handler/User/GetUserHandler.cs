using Common.Contract.Messaging;
using Core.DB;
using Core.DB.Mapper;
using Core.LIB;

namespace Core.Handler.Landlord
{
    public class GetUserHandler : RequestHandler<GetUserReq, GetUserResp>
    {
        private readonly IUserMapper _userMapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public GetUserHandler(IUserMapper userMapper,
            IRepositoryFactory repositoryFactory,
            IUnitOfWorkFactory unitOfWorkFactory, IResponseFactory responseFactory) : base(unitOfWorkFactory, responseFactory)
        {
            _userMapper = userMapper;
            _repositoryFactory = repositoryFactory;
        }

        public override GetUserResp Process(GetUserReq req)
        {
            try
            {
                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    var userRepo = _repositoryFactory.CreateUserRepository(unitOfWork);
                    var user = userRepo.GetUser(req.Email);
                    
                    return new GetUserResp()
                    {
                        userContract = _userMapper.Map(user)
                    };
                }
            }
            catch (Exception ex)
            {
                return GetErrorResp(ex, "Something went wrong");
            }
        }
    }
}
