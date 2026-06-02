using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace LibrarySystem.Application.Features.Books.Commands.CreateBook;

public class CreateBookValidator
    : AbstractValidator<CreateBookCommand>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Author)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Genre)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.PublishedYear)
            .GreaterThan(1900);
    }
}
