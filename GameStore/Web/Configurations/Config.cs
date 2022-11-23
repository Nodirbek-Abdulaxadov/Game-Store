using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web.Areas.Identity;
using Web.Areas.Identity.Data;
using Web.Data;
using Web.Services;

namespace Web.Configurations
{
    internal static class Config
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            // Add Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Add repositories and services to AppService collection
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddTransient<IGameInterface, GameRepository>();
            builder.Services.AddTransient<IGameCategoryInterface, GameCategoryRepository>();
            builder.Services.AddTransient<IGameCategoryService, GameCategoryService>();
            builder.Services.AddTransient<IGameService, GameService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ICommentInterface, CommentRepository>();
            builder.Services.AddTransient<ICommentService, CommentService>();
            builder.Services.AddTransient<IOrderInterface, OrderRepository>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IOrderDetailInterface, OrderDetailRepository>();

            var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
                //@"Filename=GameStoreDB.db"; 
                //builder.Configuration.GetConnectionString("LocalDB") ?? throw new InvalidOperationException("Connection string 'WebContextConnection' not found.");

            //builder.Services.AddDbContext<WebContext>(options =>
            //    options.UseSqlite(connectionString));
            builder.Services.AddDbContext<WebContext>(options =>
                  options.UseNpgsql(connectionString));

            builder.Services.AddDefaultIdentity<WebUser>()
                   .AddEntityFrameworkStores<WebContext>();

            // Add Application Database Context
            builder.Services.AddDbContext<GameStoreDBContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddMiddlewares(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Game}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
