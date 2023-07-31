using AutoMapper;
using BookStoreB.BookOperations.CreateBook;
using BookStoreB.BookOperations.DeleteBook;
using BookStoreB.BookOperations.GetBookDetail;
using BookStoreB.BookOperations.GetBooks;
using BookStoreB.BookOperations.UpdateBook;
using BookStoreB.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static BookStoreB.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreB.BookOperations.GetBookDetail.GetBookDetailQuery;
using static BookStoreB.BookOperations.UpdateBook.UpdateBookCommand;
using FluentValidation.Results;
using FluentValidation;

namespace BookStoreB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        //4.Eklemiş olduğumuz Dependency Injection paketi sayesinde 
        //Controller'ın kurucu fonksiyonunda mapper'ı kod içerisinde kullanılmak üzere dahil edebiliriz.
        private readonly IMapper _mapper;

        public BookController (BookStoreDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
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

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
               
                command.Model = newBook;
                CreateBookCommandValidator valiadator = new CreateBookCommandValidator();
                FluentValidation.Results.ValidationResult result = valiadator.Validate(command);
                valiadator.ValidateAndThrow(command);
                command.Handle();
                //if(result.IsValid)
                //    foreach (var item in result.Errors)
                //    {
                //        Console.WriteLine("Özellik: " + item.PropertyName + "- Error Message: " + item.ErrorMessage);
                //    }
                //else
                //    command.Handle();


            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
            return Ok();
        }
        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }

        //Delete
        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            return Ok();
           
        }



    }
}
