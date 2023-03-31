using Core.DB.Model;

namespace Core.DB.Mapper
{
    public class OrganizationMapper : IOrganizationMapper
    {
        public Common.Contract.Model.OrganizationContract Map(Organization organization)
        {
            return new Common.Contract.Model.OrganizationContract
            {
                OrganizationId = organization.OrganizationId,
                UserId = organization.UserId,
                Name = organization.Name
            };
        }
    }
}
