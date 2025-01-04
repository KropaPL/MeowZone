using System.ComponentModel.DataAnnotations;
using MeowZone.Models;
using Microsoft.AspNetCore.Identity;

namespace MeowZone.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? UserName { get; set; }
        public virtual ICollection<Cat>? UsersCats { get; set; }
        [StringLength(500)]
        public string? Bio { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public bool IsModerator { get; set; } = false;

	}
}
