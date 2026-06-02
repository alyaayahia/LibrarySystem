using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Domain.Entities;
namespace LibrarySystem.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(Guid id);

        Task<List<Member>> GetAllAsync();

        Task AddAsync(Member member);

        Task UpdateAsync(Member member);

        Task DeleteAsync(Member member);
    }
}
