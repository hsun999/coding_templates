namespace CodingTemplates.DotNet.Skills.MongoRead;

public interface IProviderReadMongoRepository
{
    ProviderData? GetById(string providerId);
}

public class ProviderReadMongoRepository : IProviderReadMongoRepository
{
    public ProviderData? GetById(string providerId)
    {
        if (string.IsNullOrWhiteSpace(providerId))
        {
            throw new ArgumentException("providerId is required.", nameof(providerId));
        }

        // Replace with real MongoDB query logic.
        return null;
    }
}
