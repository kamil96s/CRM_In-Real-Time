using CRM.Domain.Interfaces;
using CRM.Infrastructure.Persistence;
using CRM.Infrastructure.Repositories;
using CRM.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CRMDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CRM")));

            services.AddDefaultIdentity<IdentityUser>()
               // .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<CRMDbContext>();

            services.AddScoped<CRMSeeder>();

            services.AddScoped<ICRMRepository, CRMRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ICRMServiceRepository, CRMServiceRepository>();
            services.AddScoped<ILeadCallRepository, LeadCallRepository>();
        }
    }
}
