using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DungeonTyper.DAL;
using DungeonTyper.Logic.Handlers;
using DungeonTyper.Common.Utils;
using DungeonTyper.Logic;
using DungeonTyper.DAL.Factories;
using System.Data.SqlClient;
using DungeonTyper.Common;
using DungeonTyper.Logic.GameStates;
namespace DungeonTyper.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<GameSession>();
            services.AddSingleton<IConfiguration>(Configuration); //add Configuration to our services collection
            services.AddTransient<IProgressLoader, ProgressLoader>();
            services.AddTransient<IAbilityDataAccess, AbilityDataAccess>(); // register our IDataAccess class (from class library)
            services.AddTransient<ICharacterClassDataAccess, CharacterClassDataAccess>();
            services.AddTransient<ICharacterDataAccess, CharacterDataAccess>();
            services.AddTransient<IFactory<SqlConnection>, ConnectionFactory>();
            services.AddTransient<IInputHandler, InputHandler>();
            services.AddScoped<IOutputHandler, OutputHandler>();
            services.AddScoped<ICombatState, CombatState>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.Cookie.Name = ".DungeonTyper.Session";
                options.IdleTimeout = TimeSpan.FromDays(9999);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSignalR(routes =>
            {
                routes.MapHub<GameHub>("/gameHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Game}/{action=Index}/{id?}");
            });
        }
    }
}
