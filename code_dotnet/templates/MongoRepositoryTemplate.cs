namespace CodingTemplates.DotNet.Templates;

public interface IProviderMongoRepository
{
    ProviderData? GetById(string providerId);
}

public class ProviderMongoRepository : IProviderMongoRepository
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
