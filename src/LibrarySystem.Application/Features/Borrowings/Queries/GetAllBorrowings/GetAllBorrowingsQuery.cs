using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Borrowings.Queries.GetAllBorrowings;
public record GetAllBorrowingsQuery()
    : IRequest<List<BorrowingDto>>;
