using LibrarySystem.Application.Features.Books.Commands.CreateBook;
using LibrarySystem.Application.Features.Books.Queries.GetAllBooks;
using LibrarySystem.Application.Features.Books.Queries.GetBookById;
using LibrarySystem.Application.Features.Books.Commands.UpdateBook;
using LibrarySystem.Application.Features.Books.Commands.DeleteBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateBookCommand command)
    {
        var bookId =
            await _mediator.Send(command);

        return Ok(bookId);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books =
            await _mediator.Send(
                new GetAllBooksQuery());

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book =
            await _mediator.Send(
                new GetBookByIdQuery(id));

        if (book is null)
            return NotFound();

        return Ok(book);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    Guid id,
    UpdateBookCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result =
            await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result =
            await _mediator.Send(
                new DeleteBookCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }
}
