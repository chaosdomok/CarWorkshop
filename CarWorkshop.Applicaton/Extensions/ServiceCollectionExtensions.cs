using AutoMapper;
using CarWorkshop.Applicaton.ApplicationUser;
using CarWorkshop.Applicaton.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Applicaton.Mappings;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.Extensions
{
    public static class ServiceCollectionExtension
    {
            public static void AddApplication(this IServiceCollection services)
            {
                services.AddScoped<IUserContext, UserContext>();
                services.AddMediatR(typeof(CreateCarworkshopCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var UserContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CarWorkshopMappingProfile(UserContext));
            }).CreateMapper()
            );

#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
                services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała
        }
    }
}
