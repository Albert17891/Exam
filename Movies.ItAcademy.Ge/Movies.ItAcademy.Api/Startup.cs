using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Movies.ItAcademy.Api.Infastructure.Extensions;
using Movies.ItAcademy.Api.Infastructure.Mappings;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.PersistanceDB.Context;
using MoviesManagement.PersistanceDB.IdentityContext;
using MoviesManagement.Services.Models.JWT;
using Serilog;

namespace Movies.ItAcademy.Api
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
            services.AddServices();
            services.AddMapping();
            services.AddDbContext<MovieContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MovieConnection")));
            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
            services.AddControllers().AddFluentValidation(Configuration => Configuration.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });


            services.AddSwaggerGen();

            services.AddJWTAuth(Configuration);
            services.Configure<JWTConfiguration>(Configuration.GetSection(nameof(JWTConfiguration)));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });


            services.AddHealthChecks()                
                .AddDbContextCheck<MovieContext>();

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(5);
                opt.AddHealthCheckEndpoint("HealthCheck", "/health");
            }).AddInMemoryStorage();


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.MyExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI();



            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI(options => { options.UIPath = "/dashboard"; });


                endpoints.MapControllers();
            });
        }
    }
}
