using Common.Contract.Messaging;

namespace Common
{
    public interface ICoreService
    {
        public GetUserResp GetUser(GetUserReq req);
        public AddCarResp AddCar(AddCarReq req);
        public GetAllCarResp GetAllCar(GetAllCarReq req);
    }
}
