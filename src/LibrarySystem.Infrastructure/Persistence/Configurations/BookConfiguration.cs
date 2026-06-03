using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibrarySystem.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Author)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.ISBN)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Genre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)");
    }
}
