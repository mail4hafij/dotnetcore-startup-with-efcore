using Core.DB.Model;

namespace Core.DB.Repo
{
    public class OrganizationRepository : RepositoryBase, IOrganizationRepository
    {
        public OrganizationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task AddOrganization(long userId, string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("organization name can not be emtpy");
            }

            var org = new Organization(userId, name);
            await _unitOfWork.Context.Organizations.AddAsync(org);
            _unitOfWork.Context.SaveChanges();
        }
    }
}
