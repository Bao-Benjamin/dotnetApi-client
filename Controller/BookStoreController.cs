using baoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Pqc.Crypto.Ntru;
[Route("api/book")]
[ApiController]
public class BookStoreController : ControllerBase
{
    private readonly IBookStoreRepo bookStoreRepo;
    public BookStoreController(IBookStoreRepo bookStoreRepo){
        this.bookStoreRepo=bookStoreRepo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllBooks()
    {
        try
        {
            return Ok(await bookStoreRepo.GetAllBooks());
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        Console.WriteLine(id);
        try
        {
            var result = await bookStoreRepo.GetBook(id);
            if (result == null) return NotFound();
            return result;
        }

         catch (Exception)
        {
            Console.WriteLine(id);

            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }

     [HttpPost]
    public async Task<ActionResult<Book>> addBook(Book book){
        try
        {
            return Ok(await bookStoreRepo.AddBook(book));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Book>> DeleteBook(int id)
    {
        try{
            var bookToDelete = await bookStoreRepo.GetBook(id);
            if(bookToDelete == null){
                return NotFound();
            }
            return await bookStoreRepo.DeleteBook(id);
        }
        catch(Exception){
            return StatusCode(StatusCodes.Status500InternalServerError,"errrorrr !!!!!");
        }

    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Book>> UpdateBook( Book book){
        try{
            if(book.Id==null)
            return BadRequest("Khong thay id");
            var bookToUpdate = await bookStoreRepo.GetBook(book.Id);
            if(bookToUpdate==null) 
                return NotFound();
            return await bookStoreRepo.UpdateBook(book);
        }
        catch{
            return StatusCode(StatusCodes.Status500InternalServerError,"loi cap nhat data !!!");
        }
    }


}