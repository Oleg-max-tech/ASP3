using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;
using ASP3.Models;


namespace ASP3.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();
        private static List<Author> authors = new List<Author>
        {
            new Author { Id = 1, Name = "Author One", Biography = "Biography of Author One" },
            new Author { Id = 2, Name = "Author Two", Biography = "Biography of Author Two" }
        };

        // Вивести усі книжки
        public IActionResult Index()
        {
            return View(books);
        }

        // Перехід на сторінку додавання книжки
        public IActionResult AddBook()
        {
            ViewBag.Authors = authors;
            return View();
        }

        // Додавання книжки
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Count + 1;
                books.Add(book);
                return RedirectToAction("Index");
            }
            ViewBag.Authors = authors;
            return View(book);
        }

        // Видалення книжки
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction("Index");
        }

        // Редагування книжки
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Authors = authors;
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.AuthorId = book.AuthorId;
                    existingBook.Price = book.Price;
                    existingBook.Pages = book.Pages;
                }
                return RedirectToAction("Index");
            }
            ViewBag.Authors = authors;
            return View(book);
        }
    }
}
