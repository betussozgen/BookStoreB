using BookStoreB.BookOperations.CreateBook;
using BookStoreB.BookOperations.GetBookDetail;
using BookStoreB.BookOperations.GetBooks;
using BookStoreB.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStoreB.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreB.BookOperations.GetBookDetail.GetBookDetailQuery;

namespace BookStoreB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        public BookController (BookStoreDbContext context)
        {
            _context = context; 
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            
            }
            return Ok(result);
        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
               
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
            return Ok();
        }
        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == id);

            if (book is null)
                return BadRequest();

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            _context.SaveChanges();
            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id == id);
            if (book is null) 
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges(); 
            return Ok();
        }



    }
}
