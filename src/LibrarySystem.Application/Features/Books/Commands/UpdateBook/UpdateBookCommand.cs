using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Books.Commands.UpdateBook;

public record UpdateBookCommand(
    Guid Id,
    string Title,
    string Author,
    string Genre,
    decimal Price,
    int PublishedYear
) : IRequest<bool>;