namespace OpenAiApi.Tests.Helpers.Mocks.Interfaces;

public interface IHttpClientWrapper {
    Task<HttpResponseMessage> GetAsync(string? id, CancellationToken cancellationToken);
}