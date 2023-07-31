using AutoMapper;
using static BookStoreB.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreB.BookOperations.GetBookDetail.GetBookDetailQuery;
using static BookStoreB.BookOperations.GetBooks.GetBooksQuery;

namespace BookStoreB.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }

    }
}
