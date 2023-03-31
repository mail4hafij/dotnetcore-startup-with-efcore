
namespace Common.Contract.Model
{
    public class UserContract
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public List<OrganizationContract> OrganizationContracts { get; set; }
    }
}
