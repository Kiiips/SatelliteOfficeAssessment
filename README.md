# Satellite Office Assessment

A RESTful Web API built with ASP.NET Core 9.0 for managing assets with Basic Authentication.

## Overview

This project is a simple asset management API that provides CRUD operations for assets. Each asset has a name and cost, and the API includes authentication to secure endpoints.

## Features

- **Asset Management**: Create, read, update, and delete assets
- **Basic Authentication**: Secure API endpoints with username/password authentication
- **In-Memory Storage**: Assets are stored in memory using a dictionary-based store
- **RESTful Design**: Standard HTTP methods and status codes
- **JSON API**: All data exchange in JSON format

## Project Structure

```
SatelliteOfficeAssessment/
├── Controllers/
│   └── AssetsController.cs     # Asset API endpoints
├── Handlers/
│   └── BasicAuthHandler.cs     # Basic authentication implementation
├── Models/
│   └── Asset.cs               # Asset data model
├── Services/
│   └── AssetStore.cs          # In-memory asset storage
├── Properties/
│   └── launchSettings.json    # Launch configuration
├── Program.cs                 # Application entry point
├── appsettings.json          # Application settings
└── SatelliteOfficeAssessment.csproj
```

## Technology Stack

- **Framework**: ASP.NET Core 9.0
- **Language**: C#
- **Authentication**: Basic Authentication
- **Storage**: In-Memory Dictionary
- **Serialization**: System.Text.Json

## API Endpoints

All endpoints require Basic Authentication with username `123` and password `Password`.

### Get All Assets
```http
GET /assets
Authorization: Basic MTIzOlBhc3N3b3Jk
```

### Get Asset by ID
```http
GET /assets/{id}
Authorization: Basic MTIzOlBhc3N3b3Jk
```

### Update Asset Cost
```http
PATCH /assets/{id}
Authorization: Basic MTIzOlBhc3N3b3Jk
Content-Type: application/json

{
  "cost": 150
}
```

### Delete Asset
```http
DELETE /assets/{id}
Authorization: Basic MTIzOlBhc3N3b3Jk
```

## Authentication

The API uses Basic Authentication with the following credentials:
- **Username**: `123`
- **Password**: `Password`

To authenticate, include the Authorization header with Base64 encoded credentials:
```
Authorization: Basic MTIzOlBhc3N3b3Jk
```

## Default Data

The application starts with 5 pre-loaded assets:
- Asset1 (Cost: 100)
- Asset2 (Cost: 200)
- Asset3 (Cost: 300)
- Asset4 (Cost: 400)
- Asset5 (Cost: 500)

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code

### Running the Application

1. **Clone or download the project**

2. **Navigate to the project directory**
   ```powershell
   cd SatelliteOfficeAssessment
   ```

3. **Restore dependencies**
   ```powershell
   dotnet restore
   ```

4. **Run the application**
   ```powershell
   dotnet run
   ```

5. **Access the API**
   The API will be available at `http://localhost:5079` (or the port specified in launchSettings.json)

### Testing the API

You can test the API using:
- **curl** commands
- **Postman** or similar API client
- The included `.http` file with VS Code REST Client extension

Example curl command:
```bash
curl -X GET "http://localhost:5079/assets" \
  -H "Authorization: Basic MTIzOlBhc3N3b3Jk"
```

## Configuration

### Application Settings
- `appsettings.json`: Production configuration
- `appsettings.Development.json`: Development-specific settings

### Launch Settings
The application can be configured to run on different ports through `Properties/launchSettings.json`.

## Development Notes

### Special Business Logic
- Asset4 has special handling in the update operation - its cost is always set to 401 regardless of the provided value
- All assets are stored in memory and will be reset when the application restarts
- Authentication credentials are hardcoded for demonstration purposes

### Error Handling
- Returns appropriate HTTP status codes (200, 204, 400, 401, 404)
- Basic validation on request bodies
- Authentication failure returns 401 Unauthorized

## Security Considerations

⚠️ **Important**: This is a demonstration/assessment project with simplified security:
- Credentials are hardcoded in the authentication handler
- No password hashing or secure credential storage
- Basic Authentication transmits credentials in Base64 (not encrypted)
- No HTTPS configuration included

For production use, implement:
- Secure credential storage (database, environment variables)
- Password hashing (bcrypt, PBKDF2, etc.)
- HTTPS/TLS encryption
- More robust authentication (JWT, OAuth, etc.)

## License

This project is for assessment purposes.
