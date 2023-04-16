using Microsoft.Extensions.Options;
using Moq;
using OpenAiApi.Endpoints;
using OpenAiApi.Tests.Helpers.Mocks;
using OpenAiApi.Tests.Helpers.Services;
using System.Net;
using Xunit;

namespace OpenAiApi.Tests;
public abstract class AbstractGetEndpointUnitTests<T> where T : AbstractEndpoint {
    private readonly Mock<IOptions<Configurations>> _mockConfigurations;
    private readonly bool _isUnit;

    public AbstractGetEndpointUnitTests(bool isUnit) {
        _isUnit = isUnit;
        _mockConfigurations = new Mock<IOptions<Configurations>>();
        _mockConfigurations.Setup(x => x.Value).Returns(new Configurations {
            OpenAiBaseUrl = "https://api.openai.com/v1",
            ApiKey = "API_KEY"
        });
    }

    public async Task Base_GetAsync_Returns_OK_Status_Code(string? id, string? prop) {
        HttpResponseMessage response = await ArrangeAndAct(id, prop, HttpStatusCode.OK);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    public async Task Base_GetAsync_Returns_NotFound_Status_Code(string? id, string? prop) {
        HttpResponseMessage response = await ArrangeAndAct(id, prop, HttpStatusCode.NotFound);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    private async Task<HttpResponseMessage> ArrangeAndAct(string? id, string? prop, HttpStatusCode statusCode) {
        // Arrange
        var endpointClass = (T)Activator.CreateInstance(typeof(T), new object[] { _mockConfigurations.Object });
        if (_isUnit) {
            endpointClass.HttpClient = new MockHttpClient(statusCode).HttpClient;
        }

        TestType testType = new TestType();
        testType.GetTypeOfGetTest(id, prop);

        // Act
        HttpResponseMessage response = (testType.Type) switch {
            TestTypes.GetList => await endpointClass.Get(),
            TestTypes.GetId => await endpointClass.Get(id),
            TestTypes.GetIdProp => await endpointClass.Get(id, prop),
            _ => throw new NotImplementedException()
        };

        return response;
    }
}
