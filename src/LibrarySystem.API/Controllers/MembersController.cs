using LibrarySystem.Application.Features.Members.Commands.CreateMember;
using LibrarySystem.Application.Features.Members.Queries.GetAllMembers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMemberCommand command)
    {
        var memberId =
            await _mediator.Send(command);

        return Ok(memberId);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members =
            await _mediator.Send(
                new GetAllMembersQuery());

        return Ok(members);
    }
}
