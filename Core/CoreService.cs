using Common;
using Common.Contract.Messaging;
using Core.LIB;

namespace Core
{
    public class CoreService : ServiceBase, ICoreService
    {
        public CoreService(IHandlerCaller handlerCaller) : base(handlerCaller) { }

        public GetUserResp GetUser(GetUserReq req) => Process<GetUserReq, GetUserResp>(req);
        public AddCarResp AddCar(AddCarReq req) => Process<AddCarReq, AddCarResp>(req);
        public GetAllCarResp GetAllCar(GetAllCarReq req) => Process<GetAllCarReq, GetAllCarResp>(req);
    }
}
