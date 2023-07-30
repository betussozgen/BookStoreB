using Microsoft.EntityFrameworkCore;

namespace BookStoreB.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        //Default Constructor'ını olustuuruyoruz.
        //Db operasyonları için kullanılacak olan DB Context'i yaratılması
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) 
        {

        }

        //db ye entity ekliyorum.
        public DbSet<Book> Books { get; set; } 

    }
}
