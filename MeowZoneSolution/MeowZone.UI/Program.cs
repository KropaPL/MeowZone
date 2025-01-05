using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeowZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
	            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
	            {
		            options.Password.RequiredLength = 5;
		            options.Password.RequireNonAlphanumeric = false;
		            options.Password.RequireUppercase = false;
		            options.Password.RequireLowercase = true;
		            options.Password.RequireDigit = false;
		            options.Password.RequiredUniqueChars = 3;
	            })
	            .AddEntityFrameworkStores<ApplicationDbContext>()
	            .AddDefaultTokenProviders()
	            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
	            .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();


            var app = builder.Build();


            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
