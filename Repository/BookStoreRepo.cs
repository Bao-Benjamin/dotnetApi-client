using baoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Engines;

class bookStoreRepo : IBookStoreRepo
{
    private readonly BookStoreContext bookStoreContext;
    public bookStoreRepo(BookStoreContext bookStoreContext){
        this.bookStoreContext=bookStoreContext;
    }
    public async Task<Book> AddBook(Book book)
    {
        var result = await bookStoreContext.Books.AddAsync(book);
        await bookStoreContext.SaveChangesAsync();
        return result.Entity;
        
    }

    public async Task<Book> DeleteBook(int bookId)
    {
        var result = await bookStoreContext.Books.FirstOrDefaultAsync(e=>e.Id==bookId);
        if(result != null){
             bookStoreContext.Books.Remove(result);
             await bookStoreContext.SaveChangesAsync();
             return result;
        }
        return null;

    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await bookStoreContext.Books.ToListAsync();
    }

    public async Task<Book> GetBook(int bookId)
    {
        return await bookStoreContext.Books.FirstOrDefaultAsync(e=> e.Id == bookId);
    }

    public async Task<Book> UpdateBook(Book book)
    {
       var result = await bookStoreContext.Books.FirstOrDefaultAsync(e=>e.Id == book.Id);
       if(result != null){
        result.Name=book.Name;
        result.Quantity=book.Quantity;
        result.Publisher=book.Publisher;
        result.UnitPrice=book.UnitPrice;
        result.Price=book.Price;
        await bookStoreContext.SaveChangesAsync();
        return result;
       }
       return null;
    }
}