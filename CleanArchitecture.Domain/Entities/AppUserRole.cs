using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
namespace CleanArchitecture.Domain.Entities
{
    public class AppUserRole : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }

        public AppRole Role { get; set; }
    }
}
