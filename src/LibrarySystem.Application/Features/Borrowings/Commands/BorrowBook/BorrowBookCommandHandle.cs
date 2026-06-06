 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;

using LibrarySystem.Application.Common;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;

namespace LibrarySystem.Application.Features.Borrowings.Commands.BorrowBook;

public class BorrowBookCommandHandler
    : IRequestHandler<BorrowBookCommand, Result<Guid>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IBorrowingRepository _borrowingRepository;

    public BorrowBookCommandHandler(
        IBookRepository bookRepository,
        IMemberRepository memberRepository,
        IBorrowingRepository borrowingRepository)
    {
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
        _borrowingRepository = borrowingRepository;
    }

    public async Task<Result<Guid>> Handle(
        BorrowBookCommand request,
        CancellationToken cancellationToken)
    {
        var book =
            await _bookRepository.GetByIdAsync(request.BookId);

        if (book is null)
            return Result<Guid>.Failure("Book not found");

        if (!book.IsAvailable)
            return Result<Guid>.Failure("Book is not available");

        var member =
            await _memberRepository.GetByIdAsync(request.MemberId);

        if (member is null)
            return Result<Guid>.Failure("Member not found");

        if (!member.IsActive)
            return Result<Guid>.Failure("Member is not active");

        var borrowing = new Borrowing(
            request.BookId,
            request.MemberId);

        book.MarkAsBorrowed();

        await _borrowingRepository.AddAsync(borrowing);

        await _bookRepository.UpdateAsync(book);

        return Result<Guid>.Success(borrowing.Id);
    }
}