using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Options;
using EBookApi.Persistance.Authors;
using EBookApi.Persistance.Books;
using EBookApi.Persistance.Categories;
using EBookApi.Persistance.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EBookApi.Persistance.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var ConnectionString = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                options.UseNpgsql(ConnectionString!.PostgreSql, postgreSqlServerOptionsAction =>
                {
                    postgreSqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                });
            });
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepsitory>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            return services;
        }
    }
}
