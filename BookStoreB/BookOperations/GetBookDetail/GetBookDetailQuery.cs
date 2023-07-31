using AutoMapper;
using BookStoreB.Common;
using BookStoreB.DBOperations;
using static BookStoreB.BookOperations.GetBooks.GetBooksQuery;

namespace BookStoreB.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int BookId { get; set; }

        //Constructor
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //asıl işi yapacak metotum.
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            //BookDetailViewModel vm = new BookDetailViewModel();
            //vm.Title = book.Title;
            //vm.PageCount = book.PageCount;
            //vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            //vm.Genre = ((GenreEnum)book.GenreId).ToString();
            //return vm;

            return vm;

        }

        public class BookDetailViewModel
        {
            public string Title { get; set; }

            public string Genre { get; set; }
            public int PageCount { get; set; }

            public string PublishDate { get; set; } 
        }
    }
}
