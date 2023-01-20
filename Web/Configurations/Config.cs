using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
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

            #region Add Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            #endregion

            #region Add DI services
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
            #endregion

            #region Adding Database

            //using SqlServer
            //builder.AddSqlServer();

            //using Sqlite
            builder.AddSqlite();

            //using Local PostgreSql
            //builder.AddPostgresql();

            //using PostgreSql on production
            //builder.AddPostgresqlForProd();

            builder.Services.AddDefaultIdentity<WebUser>()
                   .AddEntityFrameworkStores<WebContext>();

            #endregion

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

        public static void AddSqlServer(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("LocalDB");
            builder.Services.AddDbContext<WebContext>(options =>
                  options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<GameStoreDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddSqlite(this WebApplicationBuilder builder)
        {
            var connectionString = @"Filename=GameStoreDB.db";
            builder.Services.AddDbContext<WebContext>(options =>
                  options.UseSqlite(connectionString));

            builder.Services.AddDbContext<GameStoreDBContext>(options =>
            {
                options.UseSqlite(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddPostgresql(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("LocalPostgreDB");
            builder.Services.AddDbContext<WebContext>(options =>
                  options.UseNpgsql(connectionString));

            builder.Services.AddDbContext<GameStoreDBContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddPostgresqlForProd(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
            builder.Services.AddDbContext<WebContext>(options =>
                  options.UseNpgsql(connectionString));

            builder.Services.AddDbContext<GameStoreDBContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
