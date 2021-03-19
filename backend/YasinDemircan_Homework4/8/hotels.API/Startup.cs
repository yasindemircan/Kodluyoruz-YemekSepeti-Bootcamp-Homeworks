using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotels.API.Contexts;
using hotels.API.Controllers;
using hotels.API.Filters;
using hotels.API.Infrastructure;
using hotels.API.Models.Derived;
using hotels.API.Services;
using hotels.API.Workers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;



namespace hotels.API
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
            services.Configure<HotelInfo>(
                Configuration.GetSection("HotelInfo")
            );

            services.AddDbContext<HotelApiDbContext>(options => 
            {
                options.UseInMemoryDatabase("HotelDB");
            });

            services.AddControllers(options => {
                options.Filters.Add(typeof(JsonExceptionFilters));
                options.Filters.Add<AllowOnlyRequireHttps>();
            });
            services.AddAutoMapper(option => option.AddProfile<MappingProfile>());
            services.AddScoped<IRoomService,RoomService>();
            services.AddScoped<IUserService,UserService>();            
            //services.AddSession()

            string key = Configuration.GetValue<string>("JwtTokenKey");
            byte [] keyValue = Encoding.UTF8.GetBytes(key);

            services.AddAuthentication(auth => {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                jwt.RequireHttpsMetadata = true;
                //jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyValue),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            services.AddHostedService<RoomWorkerService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerDocument();
          
          services.AddApiVersioning(options =>{
              options.DefaultApiVersion = new ApiVersion(1,0);
              options.ApiVersionReader = new MediaTypeApiVersionReader();

             
                /*
                    options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                    options.ApiVersionReader = new QueryStringApiVersionReader("v");
                */ 
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);

                options.Conventions.Controller<TestController>()
                            .HasDeprecatedApiVersion(1,0)
                            .HasApiVersion(1,1)
                            .HasApiVersion(2,0)
                            .Action(a => a.GetCustomers()).MapToApiVersion(1,1)
                            .Action(a => a.GetCustomersV2()).MapToApiVersion(2,0);
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3();
                app.UseOpenApi();
                // app.UseSwagger();
                // app.UseSwaggerUi3(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hotels.API v1"));
                
            }

          //  app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
