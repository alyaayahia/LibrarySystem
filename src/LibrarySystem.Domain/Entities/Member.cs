using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Entities;

public class Member
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string? Phone { get; private set; }

    public DateTime JoinDate { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsDeleted { get; private set; }

    public Member(
        string name,
        string email,
        string? phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");

        Id = Guid.NewGuid();

        Name = name;

        Email = email;

        Phone = phone;

        JoinDate = DateTime.UtcNow;

        IsActive = true;

        IsDeleted = false;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Delete()
    {
        IsDeleted = true;
        IsActive = false;
    }
}
