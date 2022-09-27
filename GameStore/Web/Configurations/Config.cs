using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<IGameInterface, GameRepository>();
            builder.Services.AddScoped<IGameCategoryInterface, GameCategoryRepository>();
            builder.Services.AddScoped<IGameCategoryService, GameCategoryService>();
            builder.Services.AddTransient<IGameService, GameService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Add Application Database Context
            builder.Services.AddDbContext<GameStoreDBContext>(options => 
                        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
        }

        public static void AddMiddlewares(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Game}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
