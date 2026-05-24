---
name: dotnet-write-mongodb
description: Use when implementing C#/.NET code to write strongly typed entities into MongoDB collections, including validation, mapping, persistence behavior, and unit tests.
---

# dotnet-write-mongodb

## Purpose

Implement a clean, testable .NET flow that:
1. Accepts strongly typed entities.
2. Validates required fields before persistence.
3. Maps entities into MongoDB write models/documents.
4. Writes inserts/updates to MongoDB with predictable outcomes.

## When to use

Use this skill when a user asks to:
1. Write MongoDB data in C#.
2. Persist entity/domain objects to MongoDB collections.
3. Build write pipelines (validate → map → insert/update).
4. Add or fix MongoDB write unit tests.

## Inputs to collect first

1. Entity schema (field names, types, required/optional fields).
2. MongoDB write details:
   - Database and collection names.
   - Insert vs upsert vs replace behavior.
   - Key/index constraints.
   - Batch vs single-item writes.
3. Error handling rules:
   - Fail-fast vs collect-per-row/item errors.
   - Duplicate key handling behavior.
4. Expected output contract:
   - Acknowledged result, affected count, or structured result with errors.

## Implementation pattern

1. **Define input entity model**
   - Use strongly typed entities for incoming data.
   - Keep Mongo-specific attributes explicit when required.

2. **Create repository interface**
   - Define focused write methods (for example, `Insert`, `UpsertById`).
   - Keep contracts deterministic and easy to mock.

3. **Create MongoDB write repository**
   - Validate entity and key fields.
   - Build MongoDB insert/update operations.
   - Execute writes and return clear result data.

4. **Create service/orchestrator (optional)**
   - Apply domain-level validation rules before repository calls.
   - Normalize output into consistent success/error shape.

5. **Write tests**
   - Happy path write.
   - Null/invalid entity input.
   - Missing required key fields.
   - Duplicate/conflict behavior assumptions.
   - Dependency outcomes (acknowledged/unacknowledged/exception paths).

## Design rules

1. Keep methods single-purpose.
2. Use interfaces for repository/service boundaries.
3. Keep validation and mapping explicit.
4. Return predictable write outcomes.
5. Throw only for truly invalid inputs or unrecoverable states.

## Output shape (recommended)

Use a result object such as:
1. `bool Success`
2. `int AffectedCount`
3. `IReadOnlyList<string> Errors`

## Testing checklist

1. Null/empty inputs.
2. Required field validation.
3. Insert vs upsert behavior.
4. Duplicate key handling assumptions.
5. Write acknowledgment handling.
6. Repository/service dependency behavior.

## Notes

1. Match project conventions before adding helpers or abstractions.
2. Keep changes surgical and limited to requested behavior.
3. If write conflict rules are ambiguous, state assumptions explicitly.

## Included templates

All templates are stored in the `assets` folder for direct reuse.

1. Entity template: `/dotnet-write-mongodb/assets/EntityTemplate.cs`
2. Write repository template: `/dotnet-write-mongodb/assets/WriteMongoRepositoryTemplate.cs`
3. Unit test template: `/dotnet-write-mongodb/assets/WriteMongoRepositoryTemplateTests.cs`
