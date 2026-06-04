using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Members.Commands.DeactivateMember;

public record DeactivateMemberCommand(Guid Id)
    : IRequest<bool>;