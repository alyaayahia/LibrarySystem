using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Application.Common;
using MediatR;
namespace LibrarySystem.Application.Features.Borrowings.Commands.ReturnBook;
public record ReturnBookCommand(Guid BorrowingId)
    : IRequest<Result<decimal>>;
