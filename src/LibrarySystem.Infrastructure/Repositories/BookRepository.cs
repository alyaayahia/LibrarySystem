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

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookRepository(
        LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Books
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _dbContext.Books
            .ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        _dbContext.Books.Update(book);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book book)
    {
        _dbContext.Books.Remove(book);

        await _dbContext.SaveChangesAsync();
    }
}
