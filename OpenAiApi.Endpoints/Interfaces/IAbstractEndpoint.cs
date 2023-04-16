namespace OpenAiApi.Endpoints.Interfaces;
public interface IAbstractEndpoint {
    public HttpClient HttpClient { get; }

    public Task<HttpResponseMessage> Get();

    public Task<HttpResponseMessage> Get(string id);

    public Task<HttpResponseMessage> Get(string id, string prop);
}
