using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DB.Model
{
    public class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrganizationId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        public User user { get; set; }

        public Organization(long userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        // Used for seed data
        public Organization(long organizationId, long userId, string name)
        {
            OrganizationId = organizationId;           
            UserId = userId;
            Name = name;
        }
    }
}
