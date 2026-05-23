using Moq;
using Xunit;
using Example.DotNet.CsvLoader;

namespace Example.DotNet.CsvLoader.Tests;

public class FacilityCsvProviderTests
{
    [Fact]
    public void Constructor_Should_Throw_When_Repository_Is_Null()
    {
        IFacilityMongoRepository? repository = null;

        var action = () => new FacilityCsvProvider(repository!);

        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void LoadFacilities_Should_Insert_Valid_Facilities_And_Return_Count()
    {
        var repositoryMock = new Mock<IFacilityMongoRepository>();
        var provider = new FacilityCsvProvider(repositoryMock.Object);

        var csvPath = Path.GetTempFileName();
        File.WriteAllLines(csvPath,
        [
            "FacilityId,FacilityName,FacilityType,StateCode,BedCount",
            "f-1,North Hospital,hospital,ca,300",
            " ,No Id Clinic,clinic,wa,20",
            "f-2,South Clinic,clinic,or,80"
        ]);

        var insertedCount = provider.LoadFacilities(csvPath);

        Assert.Equal(2, insertedCount);
        repositoryMock.Verify(x => x.InsertFacility(It.IsAny<FacilityData>()), Times.Exactly(2));
    }
}
