using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Application.Interfaces;
using MediatR;
namespace LibrarySystem.Application.Features.Borrowings.Queries.GetAllBorrowings;
public class GetAllBorrowingsQueryHandler
    : IRequestHandler<GetAllBorrowingsQuery, List<BorrowingDto>>
{
    private readonly IBorrowingRepository _borrowingRepository;

    public GetAllBorrowingsQueryHandler(
        IBorrowingRepository borrowingRepository)
    {
        _borrowingRepository = borrowingRepository;
    }

    public async Task<List<BorrowingDto>> Handle(
        GetAllBorrowingsQuery request,
        CancellationToken cancellationToken)
    {
        var borrowings =
            await _borrowingRepository.GetAllAsync();

        return borrowings.Select(borrowing => new BorrowingDto
        {
            Id = borrowing.Id,
            BookTitle = borrowing.Book?.Title ?? string.Empty,
            MemberName = borrowing.Member?.Name ?? string.Empty,
            BorrowDate = borrowing.BorrowDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            Status = (int)borrowing.Status,
            LateFee = borrowing.LateFee
        }).ToList();
    }
}
