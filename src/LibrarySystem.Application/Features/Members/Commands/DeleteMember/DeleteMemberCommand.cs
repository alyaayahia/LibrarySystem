using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Members.Commands.DeleteMember;

public record DeleteMemberCommand(Guid Id)
    : IRequest<bool>;
