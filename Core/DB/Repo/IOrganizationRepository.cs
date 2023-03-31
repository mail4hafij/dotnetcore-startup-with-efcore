using Core.DB.Model;

namespace Core.DB.Repo
{
    public interface IOrganizationRepository
    {
        Task AddOrganization(long userId, string name);
    }
}
