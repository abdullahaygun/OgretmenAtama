using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OgretmenAtama.Persistance.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
            configurationManager.AddJsonFile("appsettings.json");

            services.AddDbContext<OgretmenAtamaDbContext>(options => options.UseNpgsql(configurationManager.GetConnectionString("PostgreSQL")));
        }
    }
}
