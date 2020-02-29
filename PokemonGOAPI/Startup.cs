using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Services;

namespace PokemonGOAPI
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
            //Dependency Injection
            services.AddSingleton<IPokemonStatsService, PokemonStatsService>();
            services.AddSingleton<IChargedPokemonMovesService, ChargedPokemonMovesService>();
            services.AddSingleton<INestingPokemonService, NestingPokemonService>();
            services.AddSingleton<IPokemonBuddyDistancesService, PokemonBuddyDistancesService>();
            services.AddSingleton<IPokemonEncounterService, PokemonEncounterService>();
            services.AddSingleton<IPokemonCandyService, PokemonCandyService>();
            services.AddSingleton<IPokemonFastMovesService, PokemonFastMovesService>();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
