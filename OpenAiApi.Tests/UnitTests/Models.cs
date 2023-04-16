using OpenAiApi.Endpoints;
using Xunit;

namespace OpenAiApi.Tests.UnitTests;

public class Models : AbstractGetEndpointUnitTests<ModelsEndpoint> {
    public Models() : base(true) { }

    [Theory]
    [InlineData(null, null)]
    [InlineData("testId", null)]
    [InlineData("testId", "testProp")]
    public async Task GetAsync_Returns_NotFound_Status_Code(string? id, string? prop)
        => await Base_GetAsync_Returns_NotFound_Status_Code(id, prop);

    [Theory]
    [InlineData(null, null)]
    [InlineData("testId", null)]
    [InlineData("testId", "testProp")]
    public async Task GetAsync_Returns_OK_Status_Code(string? id, string? prop)
        => await Base_GetAsync_Returns_OK_Status_Code(id, prop);
}
