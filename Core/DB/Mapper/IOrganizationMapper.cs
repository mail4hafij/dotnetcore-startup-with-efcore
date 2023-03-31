using Core.DB.Model;

namespace Core.DB.Mapper
{
    public interface IOrganizationMapper
    {
        Common.Contract.Model.OrganizationContract Map(Organization organization);
    }
}
