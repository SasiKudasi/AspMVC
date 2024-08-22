using System;
using BoocStore.Core.Models;

namespace BoocStore.Core.Abstractions
{
    public interface IBookRepos
    {
        public Task<List<Book>> Get();
        public Task<Guid> Creat(Book book);
        public Task<Guid> Update(Guid id, string title, string description, decimal price);
        public Task Delite(Guid id);
    }
}

