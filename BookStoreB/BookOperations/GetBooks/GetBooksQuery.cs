using BookStoreB.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreB.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDbContext _dbContext;

        //Constructor
        public GetBooksQuery(BookStoreDbContext dbContext)
        { 
            _dbContext = dbContext; 
        }

        //asıl işi yapacak metotum.
        public List<Book> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }
    }
}
