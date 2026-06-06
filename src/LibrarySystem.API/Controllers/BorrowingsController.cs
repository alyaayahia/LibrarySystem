using LibrarySystem.Application.Features.Borrowings.Commands.BorrowBook;
using LibrarySystem.Application.Features.Borrowings.Commands.ReturnBook;
using LibrarySystem.Application.Features.Borrowings.Queries.GetAllBorrowings;
using LibrarySystem.Application.Features.Borrowings.Queries.GetBorrowingById;
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
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var borrowings =
            await _mediator.Send(
                new GetAllBorrowingsQuery());

        return Ok(borrowings);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var borrowing =
            await _mediator.Send(
                new GetBorrowingByIdQuery(id));

        if (borrowing is null)
            return NotFound();

        return Ok(borrowing);
    }
}