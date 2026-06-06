using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Borrowings.Queries.GetBorrowingById;

public class GetBorrowingByIdQueryHandler
    : IRequestHandler<GetBorrowingByIdQuery, BorrowingDetailsDto?>
{
    private readonly IBorrowingRepository _borrowingRepository;

    public GetBorrowingByIdQueryHandler(
        IBorrowingRepository borrowingRepository)
    {
        _borrowingRepository = borrowingRepository;
    }

    public async Task<BorrowingDetailsDto?> Handle(
        GetBorrowingByIdQuery request,
        CancellationToken cancellationToken)
    {
        var borrowing =
            await _borrowingRepository.GetByIdAsync(
                request.Id);

        if (borrowing is null)
            return null;

        return new BorrowingDetailsDto
        {
            Id = borrowing.Id,
            BookTitle = borrowing.Book?.Title ?? string.Empty,
            MemberName = borrowing.Member?.Name ?? string.Empty,
            BorrowDate = borrowing.BorrowDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            Status = (int)borrowing.Status,
            LateFee = borrowing.LateFee
        };
    }
}
