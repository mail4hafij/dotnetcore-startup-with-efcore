using Common;
using Common.Contract.Messaging;
using Core.LIB;

namespace Core
{
    public class CoreService : HandlerBase, ICoreService
    {
        public CoreService(IHandlerCaller handlerCaller) : base(handlerCaller) { }

        public GetUserResp GetUser(GetUserReq req) => Process<GetUserReq, GetUserResp>(req);
        public AddOrganizationResp AddOrganization(AddOrganizationReq req) => Process<AddOrganizationReq, AddOrganizationResp>(req);
    }
}
