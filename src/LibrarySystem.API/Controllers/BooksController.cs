using LibrarySystem.Application.Features.Books.Commands.CreateBook;
using LibrarySystem.Application.Features.Books.Queries.GetAllBooks;
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
}
