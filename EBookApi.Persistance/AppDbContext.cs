using System.Reflection;
using EBookApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Persistance
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(PublisherConfiguration).Assembly);



        }
    }

}
