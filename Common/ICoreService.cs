using Common.Contract.Messaging;

namespace Common
{
    public interface ICoreService
    {
        public GetUserResp GetUser(GetUserReq req);
        public AddOrganizationResp AddOrganization(AddOrganizationReq req);
    }
}
