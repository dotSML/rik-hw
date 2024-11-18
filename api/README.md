# rik-hw API

This is the backend API for the rik-hw project. It provides RESTful endpoints for data management and serves as the foundation for the client.

---

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the API](#running-the-api)
  - [Database Setup](#database-setup)
- [Environment Variables](#environment-variables)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [License](#license)

---

## Features

- RESTful API for managing resources.
- Follows a layered architecture with Domain-Driven Design principles.
- Uses **Entity Framework Core** for database management.
- Exception handling with descriptive error responses.
- Dependency Injection for better scalability and testability.

---

## Technologies

- **.NET 8**: Framework for building the API.
- **Entity Framework Core**: ORM for database operations.
- **SQLLite**: Lightweight database provider.
- **Swagger**: For API documentation.
- **xUnit**: Unit testing framework.

---


### Project Structure

#### **`/Application`**
- **`Services`**: Contains application-specific business logic. This is where use cases are implemented.
  - Example: `EventRegistrationService.cs`
- **`DTOs`**: Data Transfer Objects used for communication between the API and the application layer.
  - Example: `EventDto.cs`
- **`Validators`**: Contains input validation logic using tools like FluentValidation.
  - Example: `EventValidator.cs`
- **`Converters`**: Handles mapping between domain models and DTOs.
  - Example: `EventToEventDtoConverter.cs`

#### **`/Domain`**
- **`Entities`**: Core business objects representing the domain.
  - Example: `Event.cs`, `Attendee.cs`
- **`Interfaces`**: Domain contracts, such as repository interfaces and domain services.
  - Example: `IEventRepository.cs`

#### **`/Infrastructure`**
- **`Persistence`**: Handles database operations, such as repository implementations and EF Core configurations.
  - **`Repositories`**: Implements repository interfaces defined in the domain layer.
    - Example: `EventRepository.cs`
  - **`Configurations`**: Contains EF Core configurations for domain entities.
    - Example: `EventConfiguration.cs`
  - **`Migrations`**: Database migration files.
- **`Services`**: Infrastructure-specific implementations for external dependencies (e.g., email, file storage).
  - Example: `EmailService.cs`

#### **`/API`**
- **`Controllers`**: Defines RESTful endpoints for the application.
  - Example: `EventController.cs`
- **`Middleware`**: Custom middleware for tasks like error handling and request logging.
  - Example: `ErrorHandlerMiddleware.cs`
- **`Swagger`**: Swagger/OpenAPI configuration for documenting endpoints.

#### **`/Tests`**
- Contains unit and integration tests to verify the application functionality.
  - Example: `EventServiceTests.cs`

#### **Root Files**
- **`appsettings.json`**: Configuration for the application (e.g., database connections, environment settings).
- **`Program.cs`**: Entry point for the application, initializing the web server.

## Getting Started

### Prerequisites

Before setting up the project, ensure you have the following installed:

1. **.NET SDK 6 or later**: [Download here](https://dotnet.microsoft.com/download)
2. **Git**: To clone the repository.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/dotsml/rik-hw.git
   cd rik-hw

2. Navigate to the API directory
    ```bash
    cd src/api

3. Restore dependencies
    ```bash
    dotnet restore

### Running the API
1. Start the application
    ```bash
    dotnet  run
The API will be available at <code>http://localhost:5000</code>

### Database setup
This API uses <code>SQLLite</code> file based database solution, which is lightweight and requires no additional setup.
The database file <code>eventmanagement.db</code> is created in the project directory upon first launch of the application.
If you need to reset the database, simply delete the <code>eventmanagement.db</code> file and rerun the application.

### Environment Variables

The application relies on `appsettings.json` for configuration. You can modify the following settings in the `appsettings.json` file located in the API project directory (`src/Api`):

### API Documentation
Project has Swagger UI set up, navigate to <a>http://localhost:5000</a> once the API is running to see the available endpoints.

### Testing
The project includes a suite of service tests to ensure functionality

1. To run the tests, navigate to test project directory 
  ```bash 
  cd Tests

2. Execute all the tests:
  ```bash
  dotnet test

### Licence
This project is licensed under the MIT License.
You are free to use, modify, and distribute the project as long as the original license is included.
