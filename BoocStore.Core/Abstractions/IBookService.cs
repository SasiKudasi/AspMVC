using System;
using BoocStore.Core.Models;

namespace BoocStore.Core.Abstractions
{
	public interface IBookService
	{
        public Task<List<Book>> GetAllBooks();
        public Task<Guid> CreatBook(Book book);
        public Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
        public Task DeliteBook(Guid id);
    }
}

