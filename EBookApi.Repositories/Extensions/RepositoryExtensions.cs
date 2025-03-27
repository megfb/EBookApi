using EBookApi.Repositories.DbEntities.Authors;
using EBookApi.Repositories.DbServices;
using EBookApi.Repositories.DbUnitOfWork;
using EBookApi.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EBookApi.Repositories.Extensions
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(PgGenericRepository<>));


            return services;
        }
    }
}
