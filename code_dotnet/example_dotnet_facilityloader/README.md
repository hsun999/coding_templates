# example_dotnet_facilityloader

1. Reads facility data from CSV.
2. Maps rows to facility entities with business logic:
   - `IsActive` from status.
   - `FacilityTier` from facility name length.
3. Filters facilities where `LastUpdateDate` is older than 3 months.
4. Inserts filtered records into a Mongo repository.
