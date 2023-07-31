using FluentValidation;

namespace BookStoreB.BookOperations.CreateBook
{
    //Book modelinin özelliklerini doğrulamak istersek aşağıdaki gibi bir validasyon sınıfı oluşturmamız gerekir:
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        //constructor
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        
         }
    }
}
