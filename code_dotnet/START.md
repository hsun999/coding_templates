## General Coding Rules:

- Each method focuses on 1 task.
- Each line of code focuses on 1 step.
- Use comments/newlines to separate logical steps.
- Methods named [Verb][Entity], etc.
- Follow templates structure.
- Each class should have an unit test class

## General Unit Testing Rules:

- Test for null/empty inputs.
- Mock dependencies
- Test for dependencies returning both expected and unexpected results

## Code should follow templates:

- Entity classes - for Data (`/code_dotnet/templates/EntityTemplate.cs`)
- Service classes - for Logic (`/code_dotnet/templates/ServiceTemplate.cs`)
- Static classes - for Common/Stateless/Business Logic Functions (`/code_dotnet/templates/StaticTemplate.cs`)

## Templates for specific tasks

- Data Access (SQL): `/code_dotnet/templates/SqlRepositoryTemplate.cs`
- Data Access (MongoDB): `/code_dotnet/templates/MongoRepositoryTemplate.cs`