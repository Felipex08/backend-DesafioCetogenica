using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DesafioCetogenica.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCetogenica.API
{
    public static class Initializer
    {
        public static void Configure(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(ApplicationDBContext), typeof(ApplicationDBContext));
        }
    }
}