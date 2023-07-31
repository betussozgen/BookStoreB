using FluentValidation;

namespace BookStoreB.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator :AbstractValidator<UpdateBookCommand>   
    {
        //Rule'ları tanıttığım constructor'ım.
        public UpdateBookCommandValidator()
        {

            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        
        
        }


    }
}
