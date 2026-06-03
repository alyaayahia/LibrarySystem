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

public class MemberRepository : IMemberRepository
{
    private readonly LibraryDbContext _dbContext;

    public MemberRepository(
        LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Member?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Member>> GetAllAsync()
    {
        return await _dbContext.Members
            .ToListAsync();
    }

    public async Task AddAsync(Member member)
    {
        await _dbContext.Members.AddAsync(member);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Member member)
    {
        _dbContext.Members.Update(member);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Member member)
    {
        _dbContext.Members.Remove(member);

        await _dbContext.SaveChangesAsync();
    }
}