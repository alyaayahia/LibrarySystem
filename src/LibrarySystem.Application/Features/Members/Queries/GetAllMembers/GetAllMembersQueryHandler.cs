using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Members.Queries.GetAllMembers;

public class GetAllMembersQueryHandler
    : IRequestHandler<GetAllMembersQuery, List<MemberDto>>
{
    private readonly IMemberRepository _memberRepository;

    public GetAllMembersQueryHandler(
        IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<List<MemberDto>> Handle(
        GetAllMembersQuery request,
        CancellationToken cancellationToken)
    {
        var members =
            await _memberRepository.GetAllAsync();

        return members.Select(member => new MemberDto
        {
            Id = member.Id,
            Name = member.Name,
            Email = member.Email,
            Phone = member.Phone,
            IsActive = member.IsActive
        }).ToList();
    }
}