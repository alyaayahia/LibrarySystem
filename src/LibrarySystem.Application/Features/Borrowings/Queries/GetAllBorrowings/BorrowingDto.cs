using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Features.Borrowings.Queries.GetAllBorrowings;

public class BorrowingDto
{
    public Guid Id { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    public string MemberName { get; set; } = string.Empty;

    public DateTime BorrowDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int Status { get; set; }

    public decimal LateFee { get; set; }
}
