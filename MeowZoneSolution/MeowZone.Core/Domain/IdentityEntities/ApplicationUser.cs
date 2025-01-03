using MeowZone.Models;

namespace MeowZone.Core.Domain.IdentityEntities
{
    public class ApplicationUser
    {
        public string? UserName { get; set; }
        public List<Cat>? UsersCats { get; set; }
    }
}
