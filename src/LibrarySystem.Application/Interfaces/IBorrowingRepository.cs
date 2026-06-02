using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Domain.Entities;
namespace LibrarySystem.Application.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<Borrowing?> GetByIdAsync(Guid id);

        Task<List<Borrowing>> GetAllAsync();

        Task AddAsync(Borrowing borrowing);

        Task UpdateAsync(Borrowing borrowing);
    }
}
