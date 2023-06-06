using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MillionAndUp.Domain;
using MillionAndUp.Domain.Interfaces.Repository;
using MillionAndUp.Infraestructure.Data;
using MillionAndUp.Infraestructure.Data.Repositories;
using MillionAndUp.Infraestructure.Interfaces;
using MillionAndUp.Infraestructure.Services;
using AutoMapper;
using MillionAndUp.Api.Application.Validators;

namespace MillionAndUp.Api.IoC
{
    public static class IoCServices
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            serviceCollection.AddTransient<IRepositoryProperty<Property>, PropertyRepository>();
            serviceCollection.AddTransient<IRepositoryBase<Owner, int>, OwnerRepository>();
            serviceCollection.AddTransient<IReposityImage<PropertyImage>, PropertyImageRepository>();
            serviceCollection.AddTransient<IServiceProperty<Property>, PropertyService>();
            serviceCollection.AddTransient<IServiceImage<PropertyImage>, PropertyImageService>();
            serviceCollection.AddTransient<IServiceImage<PropertyImage>, PropertyImageService>();
            serviceCollection.AddSingleton<Validators>();
            return serviceCollection;
        }  

    }
}
