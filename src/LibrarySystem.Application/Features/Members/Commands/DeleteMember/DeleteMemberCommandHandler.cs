using LibrarySystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibrarySystem.Application.Features.Members.Commands.DeleteMember;

public class DeleteMemberCommandHandler
    : IRequestHandler<DeleteMemberCommand, bool>
{
    private readonly IMemberRepository _memberRepository;

    public DeleteMemberCommandHandler(
        IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<bool> Handle(
        DeleteMemberCommand request,
        CancellationToken cancellationToken)
    {
        var member =
            await _memberRepository.GetByIdAsync(request.Id);

        if (member is null)
            return false;

        member.Delete();

        await _memberRepository.UpdateAsync(member);

        return true;
    }
}
