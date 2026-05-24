---
name: dotnet-read-mongodb
description: Use when implementing C#/.NET code to read MongoDB documents into strongly typed entities, including query filtering, mapping, validation, and unit tests.
---

# dotnet-read-mongodb

## Purpose

Implement a clean, testable .NET flow that:
1. Reads documents from MongoDB collections.
2. Maps BSON/documents into entity classes.
3. Validates query input and mapped results.
4. Surfaces data issues clearly while preserving predictable behavior.

## When to use

Use this skill when a user asks to:
1. Read MongoDB data in C#.
2. Map MongoDB documents into entity/domain objects.
3. Build read pipelines (validate query → fetch → map → return).
4. Add or fix MongoDB read unit tests.

## Inputs to collect first

1. Entity schema (field names, types, required/optional fields).
2. MongoDB access details:
   - Database and collection names.
   - Filter fields and query behavior.
   - Sort/paging requirements.
   - Projection requirements.
3. Error handling rules:
   - Null/not-found behavior.
   - Invalid input behavior.
4. Expected output contract:
   - Single entity, list, paged result, or result object with metadata.

## Implementation pattern

1. **Define entity model**
   - Create a strongly typed entity aligned with document structure.
   - Keep Mongo annotations explicit when needed.

2. **Create repository interface**
   - Define read methods (for example, `GetById`, `FindByFilter`).
   - Keep read contract focused and testable.

3. **Create MongoDB read repository**
   - Validate query inputs.
   - Execute MongoDB filter/query.
   - Map documents to entities in one layer.

4. **Create service/orchestrator (optional)**
   - Combine query validation, repository calls, and domain-level checks.
   - Return a clear, stable output contract.

5. **Write tests**
   - Happy path with valid query.
   - Null/empty query input.
   - Not-found behavior.
   - Mapping edge cases for optional/required fields.
   - Repository dependency outcomes (expected/unexpected).

## Design rules

1. Keep methods single-purpose.
2. Use interfaces for repository/service boundaries.
3. Keep mapping logic deterministic and side-effect free.
4. Validate inputs before query execution.
5. Prefer explicit return behavior for not-found documents.

## Output shape (recommended)

Use a result object when needed, such as:
1. `TEntity? Entity`
2. `bool Found`
3. `string? Message`

Or return `TEntity?`/`IReadOnlyList<TEntity>` directly when sufficient.

## Testing checklist

1. Null/empty filter input.
2. Invalid identifier format handling.
3. Not-found document behavior.
4. Correct mapping of required and optional fields.
5. Repository/service dependency behavior.
6. Predictable exceptions only for truly invalid inputs.

## Notes

1. Match project conventions before adding helpers or abstractions.
2. Keep changes surgical and limited to requested behavior.
3. If query behavior is ambiguous, state assumptions explicitly.

## Included templates

All templates are stored in the `assets` folder for direct reuse.

1. Entity template: `/dotnet-read-mongodb/assets/EntityTemplate.cs`
2. Read repository template: `/dotnet-read-mongodb/assets/ReadMongoRepositoryTemplate.cs`
3. Unit test template: `/dotnet-read-mongodb/assets/ReadMongoRepositoryTemplateTests.cs`
