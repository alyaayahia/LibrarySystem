using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Infrastructure.Persistence.Configurations;

public class BorrowingConfiguration
    : IEntityTypeConfiguration<Borrowing>
{
    public void Configure(
        EntityTypeBuilder<Borrowing> builder)
    {
        builder.ToTable("Borrowings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LateFee)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey(x => x.BookId);

        builder.HasOne(x => x.Member)
            .WithMany()
            .HasForeignKey(x => x.MemberId);
    }
}
