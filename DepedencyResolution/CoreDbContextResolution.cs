using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAnalyticCore.Models;
using GameAnalyticCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GameAnalyticCore.DepedencyResolution
{
    public static class CoreDbContextResolution
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("ConStr")));
           

        }
    }
}
