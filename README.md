# 📚 Library Management System

A modern **Library Management System** built with **ASP.NET Core 8**, following **Clean Architecture**, **CQRS**, and **Repository Pattern** principles.

The project provides a complete backend solution for managing books, members, and borrowing operations while applying real-world software engineering practices and business rules.

---

# 🚀 Features

## 📖 Books

- Create a new book
- Update book information
- Get all books
- Get book by ID
- Soft delete books
- Track book availability

---

## 👤 Members

- Register new members
- Get all members
- Get member by ID
- Update member information
- Soft delete members
- Activate / Deactivate members

---

## 🔄 Borrowing Management

- Borrow available books
- Return borrowed books
- Prevent borrowing unavailable books
- Prevent returning an already returned borrowing
- Automatically update book availability
- Track borrowing history

---

# 🏗 Architecture

This project follows **Clean Architecture** to separate responsibilities and improve maintainability.

```
Presentation (API)
        │
Application
        │
Domain
        │
Infrastructure
```

### Layers

### API

- Controllers
- Swagger
- Dependency Injection

### Application

- CQRS
- Commands
- Queries
- Handlers
- DTOs
- Interfaces

### Domain

- Entities
- Business Rules
- Domain Logic

### Infrastructure

- Entity Framework Core
- SQL Server
- Repository Implementations

---

# ⚙ Technologies

- ASP.NET Core 8
- C#
- Entity Framework Core
- SQL Server
- MediatR
- CQRS
- Repository Pattern
- Clean Architecture
- Swagger
- Dependency Injection
- LINQ
- Git & GitHub

---

# 📂 Project Structure

```
LibrarySystem

src
│
├── LibrarySystem.API
│
├── LibrarySystem.Application
│
├── LibrarySystem.Domain
│
└── LibrarySystem.Infrastructure
```

---

# 📌 Business Rules

### Books

- A book cannot be borrowed if it is unavailable.

### Borrowings

- A borrowing cannot be returned twice.
- Returning a book automatically marks it as available again.

### Members

- Members are soft deleted instead of being permanently removed.
- Deleted members remain stored in the database for auditing purposes.

---

# 🗄 Database

Database Provider:

- SQL Server

ORM:

- Entity Framework Core

---

# 📡 API Documentation

Swagger UI is included for testing all endpoints.

Available modules:

- Books
- Members
- Borrowings

---

# ▶ Running the Project

## Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/LibrarySystem.git
```

## Restore Packages

```bash
dotnet restore
```

## Apply Migrations

```bash
dotnet ef database update
```

## Run

```bash
dotnet run
```

---

# 📷 Screenshots

> Swagger screenshots will be added soon.

---

# 🔮 Future Improvements

- JWT Authentication
- Role-Based Authorization
- Global Exception Handling
- FluentValidation
- Unit Testing
- Integration Testing
- Docker
- CI/CD Pipeline
- Azure Deployment
- Logging
- Caching

---

# 👩‍💻 Author

**Alyaa Yahia Salah**

ASP.NET Backend Developer

- GitHub: https://github.com/alyaayahia
- LinkedIn: https://linkedin.com/in/alyaayahia
- Portfolio: https://alyaayahia.vercel.app

---

# ⭐ If you like this project

Give it a ⭐ on GitHub!
