using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Domain.Entities;
namespace LibrarySystem.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(Guid id);

        Task<List<Book>> GetAllAsync();

        Task AddAsync(Book book);

        Task UpdateAsync(Book book);

        Task DeleteAsync(Book book);
    }
}
