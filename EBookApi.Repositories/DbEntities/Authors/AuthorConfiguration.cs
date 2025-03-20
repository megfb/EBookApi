using EBookApi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBookApi.Repositories.DbEntities.Authors
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Biography).HasMaxLength(250).IsRequired();
            builder.HasMany(p => p.Book).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);
        }
    }
}
