using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbEntities.Authors;
using EBookApi.Repositories.DbEntities.Books;
using EBookApi.Repositories.DbEntities.Categories;
using EBookApi.Repositories.DbEntities.Publishers;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Repositories.DbServices
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PublisherConfiguration).Assembly);



        }
    }

}
