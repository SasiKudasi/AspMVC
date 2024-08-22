using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMVCProject.Contracts;
using BoocStore.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using BoocStore.Core.Models;

namespace AspNetMVCProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _booksService;

        public BooksController(IBookService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _booksService.GetAllBooks();
            var response = books.Select(b => new BookResponce(b.Id, b.Title, b.Description, b.Price)).ToList();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] BookRequest request)
        {
            var (book, error) = Book.Create(Guid.NewGuid(), request.Title, request.Description, request.Price);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var bookId = await _booksService.CreatBook(book);
            return RedirectToAction("Index");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromForm] BookRequest request)
        {
            var bookId = await _booksService.UpdateBook(id, request.Title, request.Description, request.Price);
            return RedirectToAction("Index");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _booksService.DeliteBook(id);
            return RedirectToAction("Index");
        }
    }
}
