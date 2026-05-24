using Xunit;

namespace CodingTemplates.DotNet.Skills.MongoWrite;

public class ProviderWriteMongoRepositoryTests
{
    [Fact]
    public void Upsert_Should_Throw_When_ProviderData_Is_Null()
    {
        // Arrange
        var repository = new ProviderWriteMongoRepository();

        // Act
        var action = () => repository.Upsert(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void Upsert_Should_Throw_When_ProviderId_Is_Missing()
    {
        // Arrange
        var repository = new ProviderWriteMongoRepository();
        var providerData = new ProviderData { ProviderId = " " };

        // Act
        var action = () => repository.Upsert(providerData);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Upsert_Should_Return_False_For_Valid_Input_In_Template()
    {
        // Arrange
        var repository = new ProviderWriteMongoRepository();
        var providerData = new ProviderData
        {
            ProviderId = "provider-001",
            ProviderName = "Provider One",
            IsActive = true,
        };

        // Act
        var result = repository.Upsert(providerData);

        // Assert
        Assert.False(result);
    }
}
