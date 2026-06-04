using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Books.Queries.GetAllBooks;

public class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksQueryHandler(
        IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> Handle(
        GetAllBooksQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            IsAvailable = book.IsAvailable
        }).ToList();
    }
}