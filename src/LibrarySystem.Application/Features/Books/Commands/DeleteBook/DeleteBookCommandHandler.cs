using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler
    : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(
        IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(
        DeleteBookCommand request,
        CancellationToken cancellationToken)
    {
        var book =
            await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
            return false;

        await _bookRepository.DeleteAsync(book);

        return true;
    }
}
