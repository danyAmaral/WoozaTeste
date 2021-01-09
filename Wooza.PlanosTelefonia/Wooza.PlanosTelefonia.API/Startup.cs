using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wooza.PlanosTelefonia.Core.Interfaces;
using Wooza.PlanosTelefonia.Core.Services;
using Wooza.PlanosTelefonia.Dominio.Interfaces;
using Wooza.PlanosTelefonia.Infraestrutura;

namespace Wooza.PlanosTelefonia.API
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
            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );

            services.AddScoped<IDDD, DDDs>();
            services.AddScoped<IOperadora, Operadoras>();
            services.AddScoped<IPlanoTelefonia, Wooza.PlanosTelefonia.Infraestrutura.PlanosTelefonia>();
            services.AddScoped<IPlanosTelefoniaService, PlanosTelefoniaService>();

            var connectionString = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<Contexto>(options => options.UseSqlServer(connectionString));
            services.AddScoped<Contexto>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
