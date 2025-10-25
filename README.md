# Vidly — Movie Rental Management (Core example)

Vidly is a modern **ASP.NET Core 8** web application for managing movie rentals.  
It provides a secure and intuitive platform for administrators and users to manage movies, customers, and rental operations.

---

## Tech Stack

| Layer | Technology |
|-------|-------------|
| **Frontend** | Razor Pages / MVC Views (ASP.NET Core) | JQuery
| **Backend** | ASP.NET Core 8 |
| **ORM** | Entity Framework Core 9 |
| **Authentication** | ASP.NET Core Identity + Google OAuth |
| **Resilience** | Polly |
| **Database** | Microsoft SQL Server |
| **Containerization** | Docker & Docker Compose |

---

## Features

**User Management**
- Register and sign in using **ASP.NET Core Identity**
- Supports **Google external login** (OAuth 2.0)
- Two user roles:
  - **Admin** — full access to manage movies, customers, and rentals
  - **User** — limited access to view and rent movies

**Movie Rental Management**
- CRUD operations for Movies and Customers
- Manage Rentals (assign movies to customers)
- Validation and error handling with JQuery

**Resilience and Reliability**
- Graceful handling of transient SQL failures during startup

**Data Access**
- Built on **Entity Framework Core 9**
- Code-first migrations
- Pre-defined admin users in first migration
- SQL Server database support

**.NET Stack**
- Built with **ASP.NET Core 8**
- Dependency Injection, Logging, and Configuration out-of-the-box

**Containerization**
- Ready-to-deploy **Dockerfile** and **docker-compose.yml**
- Includes **SQL Server** service and web app container

---

## Getting Started

### 1️ Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- Google OAuth Client (for external login)

---

### 2️ Environment Variables

Set environments variables in docker-compose.yml:

```
# ASP.NET Core
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=http://+:8080

# Database
ConnectionStrings__DefaultConnection=Server=db;Database=VidlyDb;User=sa;Password=Your_strong_Password123;TrustServerCertificate=True;

# Google OAuth
Authentication__Google__ClientId=your-client-id.apps.googleusercontent.com
Authentication__Google__ClientSecret=your-client-secret
```

### 3 Run with docker

Go to main folder and run

```
docker compose up --build
```

