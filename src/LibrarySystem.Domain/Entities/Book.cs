using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Author { get; private set; }

    public string ISBN { get; private set; }

    public string Genre { get; private set; }

    public decimal Price { get; private set; }

    public bool IsAvailable { get; private set; }

    public int PublishedYear { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public bool IsDeleted { get; private set; }
    private Book()
    {
    }
    public Book(
        string title,
        string author,
        string isbn,
        string genre,
        decimal price,
        int publishedYear)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Id = Guid.NewGuid();

        Title = title;

        Author = author;

        ISBN = isbn;

        Genre = genre;

        Price = price;

        PublishedYear = publishedYear;

        IsAvailable = true;

        CreatedAt = DateTime.UtcNow;

        IsDeleted = false;
    }
    // Additional methods for business logic can be added here, such as marking the book as borrowed or returned.
    public void MarkAsBorrowed() // Example method to mark the book as borrowed
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Book is already borrowed");

        IsAvailable = false;
    }
    public void MarkAsReturned() // Example method to mark the book as returned
    {
        if (IsAvailable)
            throw new InvalidOperationException("Book is not borrowed");

        IsAvailable = true;
    }
    public void Update(
    string title,
    string author,
    string genre,
    decimal price,
    int publishedYear)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Title = title;

        Author = author;

        Genre = genre;

        Price = price;

        PublishedYear = publishedYear;
    }
    public void Delete()
    {
        IsDeleted = true;
    }
}
