using LibrarySystem.Application.Features.Borrowings.Commands.BorrowBook;
using LibrarySystem.Application.Features.Borrowings.Commands.ReturnBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BorrowingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> BorrowBook(
        BorrowBookCommand command)
    {
        var result =
            await _mediator.Send(command);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    [HttpPut("{id}/return")]
    public async Task<IActionResult> ReturnBook(Guid id)
    {
        var result =
            await _mediator.Send(
                new ReturnBookCommand(id));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}