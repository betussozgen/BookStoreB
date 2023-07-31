using BookStoreB.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreB.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {

        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }

        //Constructor
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Silenecek kitap bulunamadı.");
            }
            
           

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }


    }
}
