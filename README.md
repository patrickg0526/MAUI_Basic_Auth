# MAUI Basic Authentication

A .NET MAUI login app that validates a user's credentials against an ASP.NET Core Web API using HTTP Basic Authentication.

## Projects

- **BasicAuthWS**: ASP.NET Core Web API (HTTP, port 5081)
  - `BasicAuthentication` action filter decodes the `Authorization: Basic <base64>` header and accepts only `instructor01` / `Password01` (user name is case-insensitive). Anything else returns **401 Unauthorized**.
  - `GET /api/Values` is protected with `[BasicAuthentication]`.
  - Swagger UI at `http://localhost:5081/swagger`
- **MauiBasicAuth**: login page (User ID, Password, Login). `DataAccess/UserAuthentication.cs` sends the credentials in a Basic Authorization header and treats a success status code as an authenticated user.

## Running

1. Start the API: `dotnet run --launch-profile http` in `BasicAuthWS`.
2. Run `MauiBasicAuth` on Windows Machine and log in.
