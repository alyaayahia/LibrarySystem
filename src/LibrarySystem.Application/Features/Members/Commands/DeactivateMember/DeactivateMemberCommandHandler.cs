using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Features.Members.Commands.DeactivateMember;

public class DeactivateMemberCommandHandler
    : IRequestHandler<DeactivateMemberCommand, bool>
{
    private readonly IMemberRepository _memberRepository;

    public DeactivateMemberCommandHandler(
        IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<bool> Handle(
        DeactivateMemberCommand request,
        CancellationToken cancellationToken)
    {
        var member =
            await _memberRepository.GetByIdAsync(request.Id);

        if (member is null)
            return false;

        member.Deactivate();

        await _memberRepository.UpdateAsync(member);

        return true;
    }
}
