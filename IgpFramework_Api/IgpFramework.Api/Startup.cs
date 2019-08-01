using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgpFramework.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IgpFramework.Api.Model;
using IgpFramework.Api.Repositories;
using AutoMapper;

namespace IgpFramework.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //appsettings içindei bir sectionu getirecek ve bızım tipimize cevirecek
            var tokenManagement = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddMvc();
            services.AddDbContext<IGPCoreContext>(optionsAction: options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(cors => cors.AddDefaultPolicy(defaultCors => { defaultCors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidIssuer = tokenManagement.Issuer,
                    ValidAudience = tokenManagement.Audience
                };
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
