using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Entities;

public class Borrowing
{
    public Guid Id { get; private set; }

    public Guid BookId { get; private set; }

    public Guid MemberId { get; private set; }

    public DateTime BorrowDate { get; private set; }

    public DateTime DueDate { get; private set; }

    public DateTime? ReturnDate { get; private set; }

    public BorrowingStatus Status { get; private set; }

    public decimal LateFee { get; private set; }

    public Book? Book { get; private set; }

    public Member? Member { get; private set; }

    public Borrowing(Guid bookId, Guid memberId)
    {
        if (bookId == Guid.Empty)
            throw new ArgumentException("Book Id is required");

        if (memberId == Guid.Empty)
            throw new ArgumentException("Member Id is required");

        Id = Guid.NewGuid();

        BookId = bookId;

        MemberId = memberId;

        BorrowDate = DateTime.UtcNow;

        DueDate = BorrowDate.AddDays(14);

        Status = BorrowingStatus.Borrowed;

        LateFee = 0;
    }

    public void Return()
    {
        if (Status != BorrowingStatus.Borrowed)
            throw new InvalidOperationException("Borrowing already closed");

        ReturnDate = DateTime.UtcNow;

        if (ReturnDate > DueDate)
        {
            var lateDays =
                (int)(ReturnDate.Value - DueDate).TotalDays;

            Status = BorrowingStatus.Overdue;

            LateFee = lateDays * 5;
        }
        else
        {
            Status = BorrowingStatus.Returned;
        }
    }
}
