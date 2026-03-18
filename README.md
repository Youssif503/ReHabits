#  ReHabit – Habit Tracking Backend API

ReHabit is a backend API for a habit tracking application, built with **ASP.NET Core** and following a **Clean / Onion Architecture**.

It provides secure user authentication, image upload support, and a clear separation of concerns across Core, Repository, Service, and API layers.

---

##  Description

ReHabit exposes RESTful endpoints for user management and (extensible) habit-related operations.

It is designed as a modular, maintainable backend that can be consumed by:

* Web applications
* Mobile apps
* Desktop clients

The architecture emphasizes:

* Scalability
* Testability
* Clear separation of concerns

---

##  Features

*  **User Authentication**

  * Registration, Login, Logout
  * JWT-based authentication
  * ASP.NET Core Identity integration

*  **Profile Image Upload**

  * Upload and store user images via `ImageService`

*  **Clean Architecture**

  * Fully separated layers (Core, Repository, Services, API)

*  **Unit of Work & Repository Pattern**

  * Encapsulated data access and transaction handling

*  **Extensible Habit System**

  * Ready for habit tracking, analytics, and reporting

*  **Environment-Based Configuration**

  * Supports multiple environments via `appsettings`

*  **Modern .NET**

  * Built with .NET 10 minimal hosting model

---

##  Tech Stack

* **Backend:** ASP.NET Core Web API
* **Language:** C#
* **ORM:** Entity Framework Core
* **Database:** SQL Server
* **Authentication:** ASP.NET Core Identity + JWT
* **Architecture:** Clean / Onion Architecture
* **Logging:** Built-in ASP.NET Core Logging

---

##  Architecture Overview

The solution is divided into layers:

###  Core (`Habit.Core`)

* Domain models (e.g., `User`, `Habit`)
* Interfaces & contracts:

  * `IAuthService`
  * `IImageService`
  * `IUnitOfWork`
* ❗ No dependencies on external frameworks

---

###  Repository (`Habit.Repository`)

* EF Core implementation
* Contains:

  * `ApplicationDbContext`
  * Repositories (e.g., `HabitRepository`, `UserRepository`)
  * `UnitOfWork`

---

###  Services (`Habit.Services`)

* Business logic layer
* Includes:

  * `AuthService`
  * `ImageService`
  * `NotificationService`

---

###  API (`ReHabit.Api`)

* ASP.NET Core Web API
* Responsibilities:

  * Controllers (e.g., `AccountController`)
  * Middleware & DI configuration
  * DTOs handling

---

###  Dependency Flow

```
API → Services → Repository → Core
```

> Core is the center and has **no dependencies**.

---

##  Project Structure

```
ReHabit/
├─ Habit.Core/
│  ├─ Models/
│  │  └─ Identity/
│  │     └─ User.cs
│  ├─ ServiceContract/
│  │  ├─ IAuthService.cs
│  │  └─ IImageService.cs
│  ├─ RepositoryContract/
│  │  ├─ IUnitOfWork.cs
│  │  └─ IHabitRepository.cs
│
├─ Habit.Repository/
│  ├─ Data/
│  │  └─ ApplicationDbContext.cs
│  ├─ Repository/
│  │  ├─ HabitRepository.cs
│  │  └─ UserRepository.cs
│  ├─ UnitOfWork.cs
│
├─ Habit.Services/
│  ├─ AuthService.cs
│  ├─ ImageService.cs
│  ├─ NotificationService.cs
│
├─ ReHabit.Api/
│  ├─ Controllers/
│  │  └─ AccountController.cs
│  ├─ DTOs/
│  │  ├─ UserDto.cs
│  │  ├─ UserLoginDto.cs
│  │  └─ UserRegisterDto.cs
│  ├─ Program.cs
│
└─ README.md
```

---

##  Getting Started

###  Prerequisites

* .NET SDK **10.0**
* SQL Server
* IDE (Visual Studio / Rider / VS Code)

Check installation:

```bash
dotnet --version
```

---

###  Installation

```bash
git clone https://github.com/your-username/ReHabit.git
cd ReHabit
dotnet restore
```

---

###  Database Setup

Update connection string in:

```json
appsettings.json
```

Apply migrations:

```bash
cd ReHabit.Api
dotnet ef database update
```

Create migrations (if needed):

```bash
dotnet ef migrations add InitialCreate -p ../Habit.Repository -s .
```

---

###  Run the Project

```bash
cd ReHabit.Api
dotnet run
```

Runs on:

```
https://localhost:5001
http://localhost:5000
```

---

##  Configuration

Example `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ReHabitDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "ReHabit",
    "Audience": "ReHabitClient",
    "ExpiresInMinutes": 60
  }
}
```

---

###  Image Upload

* Stored in: `wwwroot/images`
* Managed via `ImageService`

---

##  API Endpoints

###  Authentication

#### Login

```
POST /api/Account/login
```

```json
{
  "email": "user@example.com",
  "password": "P@ssw0rd!"
}
```

---

#### Register

```
POST /api/Account/register
```

* Form-data:

  * Email
  * Name
  * Password
  * Image (optional)

---

#### Get Current User

```
GET /api/Account
```

---

#### Logout

```
POST /api/Account/logout
```

---

#### Update Password

```
POST /api/Account/update-password
```

```json
{
  "currentPassword": "old",
  "newPassword": "new"
}
```

---

##  Future Improvements

* Habit CRUD & tracking system
* Role-based authorization
* FluentValidation integration
* Pagination & filtering
* Unit & integration testing
* CI/CD pipeline (GitHub Actions)

---

##  Contributing

```bash
git checkout -b feature/your-feature-name
git commit -m "Add feature"
git push origin feature/your-feature-name
```

Then open a Pull Request 
