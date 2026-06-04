using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;

namespace LibrarySystem.Application.Features.Members.Commands.CreateMember;

public class CreateMemberCommandHandler
    : IRequestHandler<CreateMemberCommand, Guid>
{
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandHandler(
        IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<Guid> Handle(
        CreateMemberCommand request,
        CancellationToken cancellationToken)
    {
        var member = new Member(
            request.Name,
            request.Email,
            request.Phone);

        await _memberRepository.AddAsync(member);

        return member.Id;
    }
}
