namespace CodingTemplates.DotNet.Skills.MongoWrite;

public interface IProviderWriteMongoRepository
{
    bool Upsert(ProviderData providerData);
}

public class ProviderWriteMongoRepository : IProviderWriteMongoRepository
{
    public bool Upsert(ProviderData providerData)
    {
        if (providerData is null)
        {
            throw new ArgumentNullException(nameof(providerData));
        }

        if (string.IsNullOrWhiteSpace(providerData.ProviderId))
        {
            throw new ArgumentException("ProviderId is required.", nameof(providerData));
        }

        // Replace with real MongoDB write logic.
        return false;
    }
}
