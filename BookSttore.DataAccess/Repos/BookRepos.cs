using System;
using BoocStore.Core.Models;
using BoocStore.Core.Abstractions;

using BookSttore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace BookSttore.DataAccess.Repos
{
	public class BookRepos : IBookRepos
	{
		private readonly BookStoreDbContext _dbContext;

		public BookRepos(BookStoreDbContext context)
		{
			_dbContext = context;
		}

		public async Task <List<Book>> Get()
		{
			var entites = await _dbContext.Books.AsNoTracking().ToListAsync();
			var error = string.Empty;
			var books = entites.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book).ToList();
			return books; 
		}

		public async Task <Guid> Creat(Book book)
		{
			var entity = new BookEntity
			{
				Id = book.Id,
				Title = book.Title,
				Description = book.Description,
				Price = book.Price
			};
			await _dbContext.Books.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<Guid> Update(Guid id, string title, string description, decimal price)
		{
			var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
			if (book != null)
			{
				book.Title = title;
				book.Description = description;
				book.Price = price;

				await _dbContext.SaveChangesAsync();
			}

			return id;
		}

		 public async Task Delite (Guid id)
		{
			var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
			if (book != null)
			{
				_dbContext.Books.Remove(book);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}

