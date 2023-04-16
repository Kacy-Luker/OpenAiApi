using Moq;
using OpenAiApi.Tests.Helpers.Mocks.Interfaces;
using System.Net;

namespace OpenAiApi.Tests.Helpers.Mocks;
public class MockHttpClient {
    public HttpClient HttpClient { get; set; }

    public MockHttpClient(HttpStatusCode statusCode) {
        HttpResponseMessage httpResponse = new HttpResponseMessage(statusCode);
        Mock<IHttpClientWrapper> mockHttpClientWrapper = new Mock<IHttpClientWrapper>();
        _ = mockHttpClientWrapper.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(httpResponse);

        HttpClient = new HttpClient(new MockHttpMessageHandler(mockHttpClientWrapper.Object)) {
            BaseAddress = new Uri("https://mockUri")
        };
    }
}
