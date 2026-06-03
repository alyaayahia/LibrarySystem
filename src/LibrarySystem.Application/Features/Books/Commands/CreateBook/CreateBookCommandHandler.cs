using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;

namespace LibrarySystem.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandHandler
    : IRequestHandler<CreateBookCommand, Guid>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(
        IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Guid> Handle(
        CreateBookCommand request,
        CancellationToken cancellationToken)
    {
        var book = new Book(
            request.Title,
            request.Author,
            request.ISBN,
            request.Genre,
            request.Price,
            request.PublishedYear);

        await _bookRepository.AddAsync(book);

        return book.Id;
    }
}
