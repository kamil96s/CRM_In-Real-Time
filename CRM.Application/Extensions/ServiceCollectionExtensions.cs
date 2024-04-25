using AutoMapper;
using CRM.Application.ApplicationUser;
using CRM.Application.CRM.Commands.CreateCRM;
using CRM.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateCRMCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CRMMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreateCRMCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
        }
    }
}
