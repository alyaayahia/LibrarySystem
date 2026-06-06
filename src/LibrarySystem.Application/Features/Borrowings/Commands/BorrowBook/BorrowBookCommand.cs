using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using LibrarySystem.Application.Common;
namespace LibrarySystem.Application.Features.Borrowings.Commands.BorrowBook;
public record BorrowBookCommand(
    Guid BookId,
    Guid MemberId
) : IRequest<Result<Guid>>;