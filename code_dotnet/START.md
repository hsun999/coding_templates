## Code classes should separate into:

- Entity classes - for Data (`/code_dotnet/templates/EntityTemplate.cs`)
- Service classes - for Logic (`/code_dotnet/templates/ServiceTemplate.cs`)
- Static classes - for Common/Stateless Functions (`/code_dotnet/templates/StaticTemplate.cs`)

## Architecture boundaries

- Entity classes:
  - Do: hold data and validation-relevant fields.
  - Do: create an unit class class and test any fields with logic
  - Don't: call external services.
- Service classes:
  - Do: orchestrate business logic and dependencies.
  - Do: create an interface for each class
  - Do: create an unit class class, mock dependencies, and test each method
  - Don't: contain shared utility logic that should be static helpers.
- Static classes:
  - Do: provide pure/stateless helpers.
  - Do: create an unit class class and test each method
  - Don't: hold mutable shared state.

## General Coding Rules:

- Each method focuses on 1 task.
- Each line of code focuses on 1 step.
- Use comments/newlines to separate logical steps.
- Methods named [Verb][Entity], etc.

## General Unit Testing Rules:

- Test for null/empty inputs.
- Mock dependencies, test for dependencies returning expected and unexpected results

## Templates for specific tasks

- Data Access (SQL): `/code_dotnet/templates/SqlRepositoryTemplate.cs`
- Data Access (MongoDB): `/code_dotnet/templates/MongoRepositoryTemplate.cs`