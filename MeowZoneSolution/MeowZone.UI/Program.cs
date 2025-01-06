using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.ServiceContracts;
using MeowZone.Core.Services;
using MeowZone.Infrastructure.DbContext;
using MeowZone.Infrastructure.Repositories;
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

            // Repositories
            builder.Services.AddScoped<ICatsRepository, CatsRepository>();
            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            builder.Services.AddScoped<IPostsRepository, PostsRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentsRepository>();


            // Cats Services
            builder.Services.AddScoped<ICatsAdderService, CatsAdderService>();
            builder.Services.AddScoped<ICatsDeleterService, CatsDeleterService>();
            builder.Services.AddScoped<ICatsGetterService, CatsGetterService>();
            builder.Services.AddScoped<ICatsUpdaterService, CatsUpdaterService>();

            // Categories Services
            builder.Services.AddScoped<ICategoryAdderService, CategoriesAdderService>();
            builder.Services.AddScoped<ICategoryDeleterService, CategoriesDeleterService>();
            builder.Services.AddScoped<ICategoryUpdaterService, CategoriesUpdaterService>();
            builder.Services.AddScoped<ICategoryGetterService, CategoriesGetterService>();

            // Posts Services
            builder.Services.AddScoped<IPostsAdderService, PostsAdderService>();
            builder.Services.AddScoped<IPostsDeleterService, PostsDeleterService>();
            builder.Services.AddScoped<IPostsUpdaterService, PostsUpdaterService>();
            builder.Services.AddScoped<IPostsGetterService, PostsGetterService>();


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
