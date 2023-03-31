using Common.Contract.Model;
using Core.DB.Model;

namespace Core.DB.Mapper
{
    public class UserMapper : IUserMapper
    {
        private readonly IOrganizationMapper _organizationMapper;

        public UserMapper(IOrganizationMapper organizationMapper)
        {
            _organizationMapper = organizationMapper;
        }

        public Common.Contract.Model.UserContract Map(User user)
        {
            return new Common.Contract.Model.UserContract
            {
                UserId = user.UserId,
                Email = user.Email,
                OrganizationContracts = MapOrganizations(user.Organizations),
            };
        }

        private List<OrganizationContract> MapOrganizations(List<Organization> organizations)
        {
            List<OrganizationContract> result = new List<OrganizationContract>();

            foreach (Organization org in organizations)
            {
                result.Add(_organizationMapper.Map(org));
            }

            return result;
        }
    }
}
