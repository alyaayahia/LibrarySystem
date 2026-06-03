using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Repositories;

public class BorrowingRepository : IBorrowingRepository
{
    private readonly LibraryDbContext _dbContext;

    public BorrowingRepository(
        LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Borrowing?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Borrowings
            .Include(x => x.Book)
            .Include(x => x.Member)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Borrowing>> GetAllAsync()
    {
        return await _dbContext.Borrowings
            .Include(x => x.Book)
            .Include(x => x.Member)
            .ToListAsync();
    }

    public async Task AddAsync(Borrowing borrowing)
    {
        await _dbContext.Borrowings
            .AddAsync(borrowing);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Borrowing borrowing)
    {
        _dbContext.Borrowings
            .Update(borrowing);

        await _dbContext.SaveChangesAsync();
    }
}
