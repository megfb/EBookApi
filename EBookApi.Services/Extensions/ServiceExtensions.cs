using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookApi.Repositories.DbEntities.Authors;
using EBookApi.Repositories.DbServices;
using EBookApi.Repositories.GenericRepository;
using EBookApi.Services.ServicesEntities.Authors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EBookApi.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAuthorService, AuthorService>();
            return services;
        }
    }
}
