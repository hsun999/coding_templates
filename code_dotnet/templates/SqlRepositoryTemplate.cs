namespace CodingTemplates.DotNet.Templates;

public interface IProviderSqlRepository
{
    ProviderData? GetById(string providerId);
}

public class ProviderSqlRepository : IProviderSqlRepository
{
    public ProviderData? GetById(string providerId)
    {
        if (string.IsNullOrWhiteSpace(providerId))
        {
            throw new ArgumentException("providerId is required.", nameof(providerId));
        }

        // Replace with real SQL query logic.
        return null;
    }
}
