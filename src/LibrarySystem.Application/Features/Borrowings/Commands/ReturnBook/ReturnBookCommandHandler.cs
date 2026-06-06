using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Common;
using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Borrowings.Commands.ReturnBook;

public class ReturnBookCommandHandler
    : IRequestHandler<ReturnBookCommand, Result<decimal>>
{
    private readonly IBorrowingRepository _borrowingRepository;
    private readonly IBookRepository _bookRepository;

    public ReturnBookCommandHandler(
        IBorrowingRepository borrowingRepository,
        IBookRepository bookRepository)
    {
        _borrowingRepository = borrowingRepository;
        _bookRepository = bookRepository;
    }

    public async Task<Result<decimal>> Handle(
        ReturnBookCommand request,
        CancellationToken cancellationToken)
    {
        var borrowing =
            await _borrowingRepository.GetByIdAsync(
                request.BorrowingId);

        if (borrowing is null)
            return Result<decimal>.Failure(
                "Borrowing not found");

        if (borrowing.Book is null)
            return Result<decimal>.Failure(
                "Book not found");
        if (borrowing.Status != LibrarySystem.Domain.Entities.BorrowingStatus.Borrowed)
            return Result<decimal>.Failure(
                "Borrowing already closed");

        borrowing.Return();

        borrowing.Book.MarkAsReturned();

        await _borrowingRepository.UpdateAsync(borrowing);

        await _bookRepository.UpdateAsync(borrowing.Book);

        return Result<decimal>.Success(
            borrowing.LateFee);
    }
}
