using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Borrowings.Queries.GetBorrowingById;
public record GetBorrowingByIdQuery(Guid Id)
    : IRequest<BorrowingDetailsDto?>;