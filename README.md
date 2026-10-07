# MiniCRM

A full-stack customer relationship management (CRM) application built with **ASP.NET Core 10, React, TypeScript, Entity Framework Core, and SQL Server**.

MiniCRM demonstrates modern full-stack development practices, including RESTful APIs, authentication, relational data modeling, frontend routing, automated testing, CI/CD, containerization, and Microsoft Azure deployment.

## Technology Stack

### Backend
- C# / ASP.NET Core 10 Web API
- Entity Framework Core 10
- SQL Server / Azure SQL Database
- ASP.NET Core Identity
- Dependency Injection
- RESTful API architecture
- xUnit automated testing

### Frontend
- React
- TypeScript
- Vite
- React Router
- Context API
- Fetch API

### DevOps & Cloud
- Git / GitHub
- GitHub Actions (CI/CD)
- Microsoft Azure App Service
- Azure Static Web Apps
- Azure SQL Database
- Azure Managed Identity
- Docker

## Application Features

### Customer Management
- Create customers
- Retrieve customer lists
- View customer details
- Associate notes with customers
- Store and retrieve data using SQL Server

### Authentication
- ASP.NET Core Identity
- Cookie-based authentication
- Protected backend API endpoints
- Authentication status endpoint (`/api/auth/me`)
- React authentication context
- Protected frontend routes

### Frontend Navigation
- Public home page
- Login page
- Dashboard route
- React Router navigation

**Development status:** Authentication-aware frontend routing is being integrated. The dashboard is currently a placeholder, and the existing customer-management UI is being reorganized into dedicated pages.

## Project Structure

```text
MiniCRM/
├── backend/
│   └── MiniCRM/
│       ├── MiniCRM.slnx
│       ├── MiniCRM.Api/
│       │   ├── Controllers/
│       │   ├── Data/
│       │   ├── Models/
│       │   ├── Services/
│       │   ├── Dockerfile
│       │   └── Program.cs
│       └── MiniCRM.Tests/
│
├── frontend/
│   └── minicrm-ui/
│       ├── src/
│       │   ├── api/
│       │   ├── auth/
│       │   ├── components/
│       │   ├── pages/
│       │   ├── App.tsx
│       │   └── main.tsx
│       ├── package.json
│       └── vite.config.ts
│
└── .github/
    └── workflows/
```

## Architecture

MiniCRM uses a React frontend that communicates with an ASP.NET Core Web API.

```text
React + TypeScript
        |
        | HTTPS / REST
        v
ASP.NET Core Web API
        |
        +---- ASP.NET Core Identity
        |
        +---- Application Services
        |
        +---- Entity Framework Core
                    |
                    v
                 SQL Server
```

The frontend handles presentation, navigation, and user interaction. The backend handles business logic, authentication, authorization, and database operations.

## Database Design

The application currently includes two primary CRM entities.

**Customer**
- Id
- Name
- Email
- Notes

**Note**
- Id
- CustomerId
- Text
- CreatedAtUtc

A customer can have multiple notes, establishing a one-to-many relationship.

ASP.NET Core Identity manages authentication-related database entities separately.

## Running Locally

### Prerequisites

- .NET 10 SDK
- Node.js and npm
- SQL Server or SQL Server Express
- Visual Studio 2026 or VS Code
- Git

### 1. Clone the Repository

```bash
git clone https://github.com/salvatoreallegra/MiniCRM.git
cd MiniCRM
```

### 2. Configure the Backend

Navigate to:

```text
backend/MiniCRM/
```

Configure `ConnectionStrings:DefaultConnection` using local development configuration or .NET user secrets.

The connection string must point to an accessible SQL Server instance with appropriate permissions.

Apply existing Entity Framework Core migrations to initialize the database.

### 3. Start the API

Open `MiniCRM.slnx` in Visual Studio and run `MiniCRM.Api` using the HTTPS launch profile.

The development API is configured to run at:

```text
https://localhost:7238
```

### 4. Configure the Frontend

Navigate to:

```bash
cd frontend/minicrm-ui
```

Install dependencies:

```bash
npm install
```

Create or update `.env.development`:

```env
VITE_API_BASE_URL=https://localhost:7238
```

Start the development server:

```bash
npm run dev
```

Open:

```text
http://localhost:5173
```

## Authentication and Authorization

MiniCRM uses ASP.NET Core Identity with cookie-based authentication.

The frontend sends authenticated requests using:

```typescript
fetch(url, {
    credentials: "include"
});
```

The backend validates authentication cookies and enforces authorization on protected API endpoints.

The authentication status endpoint is:

```http
GET /api/auth/me
```

Protected React routes use `AuthContext` and `ProtectedRoute` to determine whether users should access authenticated pages.

Frontend route protection is a user-interface mechanism; backend authorization remains responsible for securing application data.

## Azure Deployment

MiniCRM has been deployed using the following Azure services:

| Component | Azure Service |
|---|---|
| Backend API | Azure App Service |
| Frontend | Azure Static Web Apps |
| Database | Azure SQL Database |
| Database authentication | Azure Managed Identity |
| CI/CD | GitHub Actions |

### Deployment URLs

**Frontend**

https://jolly-river-065bfee10.6.azurestaticapps.net

**Backend API**

https://minicrmapi20260909123711-dtdub4fefbcmdtcf.westus3-01.azurewebsites.net

The frontend production configuration specifies the deployed backend through `VITE_API_BASE_URL`.

The deployed version may differ from the latest local development changes.

## Docker

The backend includes a Dockerfile for containerizing the ASP.NET Core API.

Local containerized development and SQL Server connectivity are still being refined. A complete Docker Compose configuration for the API and database is planned.

## CI/CD

GitHub Actions is configured to automate application build and deployment workflows.

The project uses a `develop` branch for its development and deployment workflow.

The CI/CD setup includes integration with Azure hosting services.

## Development Roadmap

- [x] ASP.NET Core Web API
- [x] Entity Framework Core and SQL Server
- [x] Customer and note entities
- [x] Customer API operations
- [x] ASP.NET Core Identity authentication
- [x] React and TypeScript frontend
- [x] Azure deployment
- [x] GitHub Actions CI/CD
- [x] Backend Dockerfile
- [x] React Router integration
- [x] Authentication context and protected routes
- [ ] Complete frontend login-state integration
- [ ] Restore customer-management screens within routed pages
- [ ] Implement functional dashboard
- [ ] Add shared navigation and professional styling
- [ ] Add customer search and filtering
- [ ] Implement complete logout workflow
- [ ] Expand automated tests
- [ ] Complete Docker Compose development environment

## Purpose

MiniCRM is a full-stack software engineering project designed to demonstrate practical experience with modern .NET development, React, relational databases, cloud infrastructure, application security, and automated deployment.

The project is under active development.
