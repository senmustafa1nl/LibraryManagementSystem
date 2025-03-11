using LibraryManagement.Models;
using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Services
{
    public interface ILibraryService
    {
        // Book Operations
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);

        // Author Operations
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}