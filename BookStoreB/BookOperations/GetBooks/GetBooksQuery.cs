using AutoMapper;
using BookStoreB.Common;
using BookStoreB.DBOperations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStoreB.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        //Constructor
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        { 
            _dbContext = dbContext; 
            _mapper = mapper;
        }

        //asıl işi yapacak metotum.
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            //List<BooksViewModel> vm = new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //        PageCount = book.PageCount
            //    });
            //}
            //return vm;
            return vm;
        }

        //View Model:
        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string  PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
