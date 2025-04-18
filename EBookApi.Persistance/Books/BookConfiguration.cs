using EBookApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBookApi.Persistance
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Description).HasMaxLength(250).IsRequired();

        }
    }
}
