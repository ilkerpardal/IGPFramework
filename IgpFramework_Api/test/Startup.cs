using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

namespace IgpFramework.Api
{
    public class Startup : BaseStartUp
    {
        public Startup(IConfiguration configuration ) : base(configuration)
        {           
            
        }
        public  override void  ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            base.ConfigureServices(services);
        }
    }
}
