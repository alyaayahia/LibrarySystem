using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Members.Queries.GetMemberById;

public class GetMemberByIdQueryHandler
    : IRequestHandler<GetMemberByIdQuery, MemberDto?>
{
    private readonly IMemberRepository _memberRepository;

    public GetMemberByIdQueryHandler(
        IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<MemberDto?> Handle(
        GetMemberByIdQuery request,
        CancellationToken cancellationToken)
    {
        var member =
            await _memberRepository.GetByIdAsync(
                request.Id);

        if (member is null)
            return null;

        return new MemberDto
        {
            Id = member.Id,
            Name = member.Name,
            Email = member.Email,
            Phone = member.Phone,
            IsActive = member.IsActive
        };
    }
}
