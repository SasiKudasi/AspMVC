using System;
using BookSttore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoocStore.Core.Models;
namespace BookSttore.DataAccess.Configure
{
	public class BookConfigure : IEntityTypeConfiguration<BookEntity>
	{
		public BookConfigure()
		{
		}

        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
			builder.HasKey(x => x.Id);
			builder.Property(t => t.Title)
				.HasMaxLength(Book.MAX_TITLE_LENGHT)
				.IsRequired();
			builder.Property(d => d.Description)
				.IsRequired();
			builder.Property(p => p.Price)
				.IsRequired();
        }
    }
}

