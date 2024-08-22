using System;
using BoocStore.Core.Abstractions;
using BoocStore.Core.Models;

namespace BookStore.Application.Services
{
	public class BooksService : IBookService
	{
        private readonly IBookRepos _repos;

        public BooksService(IBookRepos repos)
		{
            _repos = repos;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _repos.Get();
        }

        public async Task<Guid> CreatBook(Book book)
        {
            return await _repos.Creat(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            return await _repos.Update(id, title, description, price);
        }

        public async Task DeliteBook(Guid id)
        {
            await _repos.Delite(id); 
        }
	}
}

