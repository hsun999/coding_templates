using Xunit;
using Example.DotNet.CsvLoader;

namespace Example.DotNet.CsvLoader.Tests;

public class FacilityMongoRepositoryTests
{
    [Fact]
    public void InsertFacility_Should_Throw_When_FacilityData_Is_Null()
    {
        var repository = new FacilityMongoRepository();

        var action = () => repository.InsertFacility(null!);

        Assert.Throws<ArgumentNullException>(action);
    }
}
