using OpenAiApi.Tests.Helpers.Mocks.Interfaces;

namespace OpenAiApi.Tests.Helpers.Mocks;

public class MockHttpMessageHandler : HttpMessageHandler {
    private readonly IHttpClientWrapper _httpClientWrapper;

    public MockHttpMessageHandler(IHttpClientWrapper httpClientWrapper)
        => _httpClientWrapper = httpClientWrapper;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    ) => await _httpClientWrapper.GetAsync(request.RequestUri.ToString(), cancellationToken);
}