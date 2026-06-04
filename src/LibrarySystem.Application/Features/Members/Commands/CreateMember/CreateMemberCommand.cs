using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Members.Commands.CreateMember;

public record CreateMemberCommand(
    string Name,
    string Email,
    string? Phone
) : IRequest<Guid>;
