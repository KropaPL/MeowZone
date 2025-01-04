using MeowZone.Models;
using Microsoft.AspNetCore.Identity;

namespace MeowZone.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? UserName { get; set; }
        public virtual ICollection<Cat>? UsersCats { get; set; }
    }
}
