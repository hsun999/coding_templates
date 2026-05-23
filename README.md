# coding_templates

Reusable coding templates with simple structure and conventions.

## Quick start

1. Pick the template type:
   - Entity: data model shape.
   - Service: business logic and dependency orchestration.
   - Static: stateless helper logic.
2. Copy a template from `code_dotnet/templates`.
3. Rename class, namespace, and members for your domain.
4. Add input validation and unit tests.
5. Run build/test checks.

## .NET template map

- Entity template: `code_dotnet/templates/EntityTemplate.cs`
- Service template: `code_dotnet/templates/ServiceTemplate.cs`
- Static template: `code_dotnet/templates/StaticTemplate.cs`
- SQL data access template: `code_dotnet/templates/SqlRepositoryTemplate.cs`
- MongoDB data access template: `code_dotnet/templates/MongoRepositoryTemplate.cs`

## Recommended checks

- `dotnet format`
- `dotnet build`
- `dotnet test`
