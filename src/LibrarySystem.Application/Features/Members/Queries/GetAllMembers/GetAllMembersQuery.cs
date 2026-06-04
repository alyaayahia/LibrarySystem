using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace LibrarySystem.Application.Features.Members.Queries.GetAllMembers;

public record GetAllMembersQuery()
    : IRequest<List<MemberDto>>;
