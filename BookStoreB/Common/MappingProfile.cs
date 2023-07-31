using AutoMapper;
using System.Runtime.Intrinsics.X86;
using System;
using static BookStoreB.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreB.BookOperations.GetBookDetail.GetBookDetailQuery;
using static BookStoreB.BookOperations.GetBooks.GetBooksQuery;

namespace BookStoreB.Common
{
    //3.Mapper Konfigürasyonu için Profile sınıfından kalıtım alan aşağıdaki gibi bir sınıf implemente etmemiz gerekir.


    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            //Öncelikle Book tipindeki bir objenin BookDetailViewModel tipindeki bir objeye dönüştürülebildiğini görürüz.
            //Ve ForMember() kullanımı da şunu söylüyor.
            //BookDetailViewModel içerisindeki Genre özel bir şekilde oluşuyor.
            //Source olan Book objesi içerisindeki GenreId'nin GenreEnum'daki string karşılığıdır.
            //Eğer book objesi içerisine bakarsak Genre diye bir özellik göremeyiz.
            //Ama BookDetailView modeline mapleme yaptığımızda Genre özelliğini görebiliriz.
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }

    }
}
