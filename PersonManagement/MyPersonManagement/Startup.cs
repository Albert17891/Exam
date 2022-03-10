using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyPersonManagement.Infastucture.AddServices;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using PersonManagement.ServiceRebo;
using MyPersonManagement.Infastucture.Mapping;
using MyPersonManagement.Infastucture.Handler;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using MyPersonManagement.Infastucture.Extension;
using PersonService.Model;
using PersonManagment.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;
using PersonManagment.PersistenceDB.SeedFile;

namespace MyPersonManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddService();
            services.AddControllers();
            services.AddRegisterMapping();
            services.AddJwtAuth(Configuration);
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<JwtConfiguration>(Configuration.GetSection(nameof(JwtConfiguration)));

            services.AddDbContext<PersonContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddAuthentication("BasicAuthentication")
            //  .AddScheme<AuthenticationSchemeOptions, BasicAutenticationHandler>("BasicAuthentication", null);
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI();

           // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            

           // Seed.AddSeed(app.ApplicationServices );
        }
    }
}
    