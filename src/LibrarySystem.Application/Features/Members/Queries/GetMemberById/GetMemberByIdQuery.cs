using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Members.Queries.GetMemberById;

public record GetMemberByIdQuery(Guid Id)
    : IRequest<MemberDto?>;
