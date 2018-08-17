using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd_asp_practice.Data.API.Services;
using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Data.Infrastructure;
using ddd_asp_practice.Data.Infrastructure.Repositories;
using ddd_asp_practice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ddd_asp_practice {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddScoped<PartyDBContext>(_ => new PartyDBContext());

            services.AddScoped<IRepository<PartyDomainEntity>, PartyRepository>();
            services.AddScoped<IRepository<FirmPartyGoerDomainEntity>, FirmPartyGoerRepository>();
            services.AddScoped<IRepository<PersonPartyGoerDomainEntity>, PersonPartyGoerRepository>();

            services.AddScoped<IPartyService, PartyService>();
            services.AddScoped<IService<FirmPartyGoerViewModel>, FirmPartyGoerService>();
            services.AddScoped<IService<PersonPartyGoerViewModel>, PersonPartyGoerService>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Party/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Party}/{action=Index}/{id?}/{name?}");
            });
        }
    }
}
