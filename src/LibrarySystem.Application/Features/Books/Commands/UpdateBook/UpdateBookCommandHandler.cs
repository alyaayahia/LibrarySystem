using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler
    : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(
        IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(
        UpdateBookCommand request,
        CancellationToken cancellationToken)
    {
        var book =
            await _bookRepository.GetByIdAsync(
                request.Id);

        if (book is null)
            return false;

        book.Update(
            request.Title,
            request.Author,
            request.Genre,
            request.Price,
            request.PublishedYear);

        await _bookRepository.UpdateAsync(book);

        return true;
    }
}
