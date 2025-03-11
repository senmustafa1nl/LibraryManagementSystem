using LibraryManagement.Models;
using LibraryManagement.Models.ViewModels;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement.Models.ViewModels;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly ILibraryService _libraryService;

        public BookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: Book/List
        public IActionResult List()
        {
            var books = _libraryService.GetAllBooks();
            var viewModels = books.Select(b => new BookViewModel
            {
                Book = b,
                AuthorName = _libraryService.GetAuthorById(b.AuthorId)?.FirstName + " " +
                           _libraryService.GetAuthorById(b.AuthorId)?.LastName
            }).ToList();

            return View(viewModels);
        }

        // GET: Book/Details/5
        public IActionResult Details(int id)
        {
            var book = _libraryService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookViewModel
            {
                Book = book,
                AuthorName = _libraryService.GetAuthorById(book.AuthorId)?.FirstName + " " +
                           _libraryService.GetAuthorById(book.AuthorId)?.LastName
            };

            return View(viewModel);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            var authors = _libraryService.GetAllAuthors();
            var viewModel = new BookViewModel
            {
                Book = new Book(), 
                Authors = new SelectList(authors, "Id", "LastName")
            };
            return View(viewModel);
        }


        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)  
        {
            if (ModelState.IsValid)
            {
                _libraryService.AddBook(book);
                return RedirectToAction(nameof(List));
            }

            return View(book);
        }
        // GET: Book/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _libraryService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookViewModel
            {
                Book = book,
                Authors = new SelectList(_libraryService.GetAllAuthors(), "Id", "LastName")
            };

            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            Console.WriteLine($"Edit POST called with id: {id}");

            if (id != book.Id)
            {
                Console.WriteLine("ID mismatch, returning NotFound()");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("Updating book...");
                _libraryService.UpdateBook(book);
                return RedirectToAction(nameof(List));
            }

            Console.WriteLine("Model state invalid");
            return View(book);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _libraryService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookViewModel
            {
                Book = book,
                AuthorName = _libraryService.GetAuthorById(book.AuthorId)?.FirstName + " " +
                           _libraryService.GetAuthorById(book.AuthorId)?.LastName
            };

            return View(viewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _libraryService.DeleteBook(id);
            return RedirectToAction(nameof(List));
        }
    }
}