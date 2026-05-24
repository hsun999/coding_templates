using Xunit;

namespace CodingTemplates.DotNet.Skills.MongoRead;

public class ProviderReadMongoRepositoryTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GetById_Should_Throw_When_ProviderId_Is_Null_Or_Empty(string? providerId)
    {
        // Arrange
        var repository = new ProviderReadMongoRepository();

        // Act
        var action = () => repository.GetById(providerId!);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void GetById_Should_Return_Null_For_Valid_Input_In_Template()
    {
        // Arrange
        var repository = new ProviderReadMongoRepository();

        // Act
        var result = repository.GetById("provider-001");

        // Assert
        Assert.Null(result);
    }
}
