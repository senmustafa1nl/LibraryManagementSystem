using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class LibraryService : ILibraryService
    {
        // In-memory data storage
        private static List<Book> _books = new();
        private static List<Author> _authors = new();
        private static int _bookId = 1;
        private static int _authorId = 1;

        // Book Operations
        public List<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = _bookId++;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.AuthorId = book.AuthorId;
                existingBook.Genre = book.Genre;
                existingBook.PublishDate = book.PublishDate;
                existingBook.ISBN = book.ISBN;
                existingBook.CopiesAvailable = book.CopiesAvailable;
            }
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        // Author Operations
        public List<Author> GetAllAuthors() => _authors;

        public Author GetAuthorById(int id) => _authors.FirstOrDefault(a => a.Id == id);

        public void AddAuthor(Author author)
        {
            author.Id = _authorId++;
            _authors.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            var existingAuthor = _authors.FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.FirstName = author.FirstName;
                existingAuthor.LastName = author.LastName;
                existingAuthor.DateOfBirth = author.DateOfBirth;
            }
        }

        public void DeleteAuthor(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                // Remove all books by this author
                _books.RemoveAll(b => b.AuthorId == id);
                _authors.Remove(author);
            }
        }

        
        public LibraryService()
        {
            // Add initial authors
            AddAuthor(new Author { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) });
            AddAuthor(new Author { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1975, 5, 15) });

            AddBook(new Book
            {
                Title = "Introduction to C#",
                AuthorId = 1,
                Genre = "Programming",
                PublishDate = new DateTime(2020, 1, 1),
                ISBN = "123-4567890123",
                CopiesAvailable = 5
            });

            AddBook(new Book
            {
                Title = "Advanced ASP.NET Core",
                AuthorId = 2,
                Genre = "Web Development",
                PublishDate = new DateTime(2021, 6, 15),
                ISBN = "987-6543210987",
                CopiesAvailable = 3
            });
        }
    }
}