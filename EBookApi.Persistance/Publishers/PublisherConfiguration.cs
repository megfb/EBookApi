using EBookApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBookApi.Persistance
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.HasMany(p => p.Book).WithOne(p => p.Publisher).HasForeignKey(p => p.PublisherId);
        }
    }
}
