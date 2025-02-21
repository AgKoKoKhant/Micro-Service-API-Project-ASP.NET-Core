# Micro-Service-API-Project-ASP.NET-Core

## Overview
This project is a **Microservices-based API** built with **ASP.NET Core**. It leverages **RabbitMQ** for messaging and includes an API Gateway for routing requests efficiently.

## Features
- **Microservices Architecture** for scalability and maintainability.
- **RabbitMQ Integration** for asynchronous messaging.
- **API Gateway** to manage and route service requests.
- **.NET Core** based backend services.
- **Configuration Management** using `appsettings.json`.

## Folder Structure
```
├── Alpha.ServiceB.Infrastructure  # Service B infrastructure setup
├── ApiGateWays/Alpha.ApiGateWay   # API Gateway handling requests
├── Properties                     # Project properties
├── Services                       # Backend microservices
├── obj                            # Build artifacts
├── .gitignore                     # Ignore unnecessary files
├── AlphProject.csproj              # Project file
├── AlphProject.sln                 # Solution file
├── Program.cs                      # Entry point of the application
├── appsettings.json                # Main configuration file
├── appsettings.Development.json    # Development configuration
```

## Requirements
- .NET Core SDK 6.0 or later
- RabbitMQ Server
- Docker (optional for containerized deployment)

## Setup & Installation
1. **Clone the repository:**
   ```sh
   git clone https://github.com/AgKoKoKhant/Micro-Service-API-Project-ASP.NET-Core.git
   cd Micro-Service-API-Project-ASP.NET-Core
   ```
2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```
3. **Update `appsettings.json`** with RabbitMQ configuration.
4. **Run the project:**
   ```sh
   dotnet run
   ```

## Deployment
- Use **Docker Compose** for containerized deployment.
- Deploy with **Azure App Services** or **AWS Elastic Beanstalk**.

## Contributing
Feel free to fork and contribute! Open an issue for any feature requests or bugs.

## License
MIT License

---
Developed by **AgKoKoKhant** 🚀
