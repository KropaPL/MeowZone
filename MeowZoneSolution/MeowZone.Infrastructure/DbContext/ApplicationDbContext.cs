using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeowZone.Infrastructure.DbContext
{
	internal class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{

		public virtual DbSet<Cat> Cats { get; set; }	
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
	}
}
