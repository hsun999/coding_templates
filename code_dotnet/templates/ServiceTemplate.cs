namespace CodingTemplates.DotNet.Templates;

public interface IOtherService
{
    ProviderData FetchProviderData(string providerId);
}

public interface IProviderService
{
    ProviderData GetProviderData(string providerId);
    ProviderViewData GetProviderViewData(string providerId);
}

public class ProviderService : IProviderService
{
    private readonly IOtherService _otherService;

    public ProviderService(IOtherService otherService)
    {
        _otherService = otherService ?? throw new ArgumentNullException(nameof(otherService));
    }

    public ProviderData GetProviderData(string providerId)
    {
        if (string.IsNullOrWhiteSpace(providerId))
        {
            throw new ArgumentException("providerId is required.", nameof(providerId));
        }

        return _otherService.FetchProviderData(providerId);
    }

    public ProviderViewData GetProviderViewData(string providerId)
    {
        var providerData = GetProviderData(providerId);

        return ProviderViewDataMapper.MapProviderDataToViewData(providerData);
    }
}
