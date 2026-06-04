using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler
    : IRequestHandler<GetBookByIdQuery, BookDto?>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(
        IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto?> Handle(
        GetBookByIdQuery request,
        CancellationToken cancellationToken)
    {
        var book =
            await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
            return null;

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            IsAvailable = book.IsAvailable
        };
    }
}
