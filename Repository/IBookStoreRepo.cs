using baoAPI.Models;

public interface IBookStoreRepo
{
    Task<IEnumerable<Book>> GetAllBooks();
    Task<Book> GetBook(int bookId);
    Task<Book> AddBook(Book book);
    Task<Book> UpdateBook(Book book);
    Task<Book> DeleteBook(int bookId);
}