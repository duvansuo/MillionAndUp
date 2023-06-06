using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MillionAndUp.Domain;
using MillionAndUp.Domain.Interfaces.Repository;
using MillionAndUp.Infraestructure.Data;
using MillionAndUp.Infraestructure.Data.Repositories;
using MillionAndUp.Infraestructure.Interfaces;
using MillionAndUp.Infraestructure.Services;
using AutoMapper;

namespace MillionAndUp.Api.IoC
{
    public static class IoCServices
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            serviceCollection.AddTransient<IRepository<Property, int>, PropertyRepository>();
            serviceCollection.AddTransient<IRepository<Owner, int>, OwnerRepository>();
            serviceCollection.AddTransient<IReposityImage<PropertyImage>, PropertyImageRepository>();
            serviceCollection.AddTransient<IServiceProperty, PropertyService>();
            serviceCollection.AddTransient<IServiceImage<PropertyImage>, PropertyImageService>();

            return serviceCollection;
        }
        public static string FirstCharToUpper(this string input) =>
           input switch
           {
               null => throw new ArgumentNullException(nameof(input)),
               "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
               _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1).ToString().ToLower())
           };

        public static bool IsLabs(this IWebHostEnvironment env)
        {
            return env.EnvironmentName.ToLower() == "Development" || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "Development";
        }



    }
}
