using LibraryManagement.Models;
using LibraryManagement.Models.ViewModels;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement.Models.ViewModels;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILibraryService _libraryService;

        public AuthorController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: Author/List
        public IActionResult List()
        {
            var authors = _libraryService.GetAllAuthors();
            return View(authors);
        }

        // GET: Author/Details/5
        public IActionResult Details(int id)
        {
            var author = _libraryService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            var viewModel = new AuthorViewModel
            {
                Author = author,
                Books = _libraryService.GetAllBooks().Where(b => b.AuthorId == id).ToList()
            };

            return View(viewModel);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,DateOfBirth")] Author author)
        {
            if (ModelState.IsValid)
            {
                _libraryService.AddAuthor(author);
                return RedirectToAction(nameof(List));
            }
            return View(author);
        }

        // GET: Author/Edit/5
        public IActionResult Edit(int id)
        {
            var author = _libraryService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _libraryService.UpdateAuthor(author);
                return RedirectToAction(nameof(List));
            }
            return View(author);
        }

        // GET: Author/Delete/5
        public IActionResult Delete(int id)
        {
            var author = _libraryService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _libraryService.DeleteAuthor(id);
            return RedirectToAction(nameof(List));
        }
    }
}