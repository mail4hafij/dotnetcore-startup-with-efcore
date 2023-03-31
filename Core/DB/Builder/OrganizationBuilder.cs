using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.DB.Model;

namespace Core.DB.Builder
{
    public class OrganizationBuilder : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");
            builder.Property(p => p.OrganizationId).HasDefaultValueSql("NEXT VALUE FOR PrimaryKeyGenerator");
            builder.Property(p => p.UserId);
            builder.Property(p => p.Name);

            builder.HasData(
                new Organization(1, 1, "my organization")
            );
            
        }
    }
}
