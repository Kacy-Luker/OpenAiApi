using OpenAiApi.Endpoints.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace OpenAiApi.Endpoints;
public abstract class AbstractEndpoint : IAbstractEndpoint {
    public HttpClient HttpClient { get; set; }

    protected AbstractEndpoint(Configurations configurations) {
        HttpClient = new HttpClient();
        HttpClient.BaseAddress = new System.Uri($"{configurations.OpenAiBaseUrl}/{GetClassEndpoint()}");
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configurations.ApiKey);
    }

    public async Task<HttpResponseMessage> Get() => await GetAsync(null, null);

    public async Task<HttpResponseMessage> Get(string id) => await GetAsync($"/:{id}", null);

    public async Task<HttpResponseMessage> Get(string id, string prop) => await GetAsync($"/{id}", $"/{prop}");

    private async Task<HttpResponseMessage> GetAsync(string? id, string? prop) {
        string additionalParams = $"{id}{prop}";
        var response = await HttpClient.GetAsync(additionalParams);
        return response;
    }

    protected string GetClassEndpoint() {
        string targetClassName = GetType().Name;
        string subStringToRemove = "Endpoint";

        int index = targetClassName.IndexOf(subStringToRemove);
        string targetUrl = (index < 0)
            ? targetClassName
            : targetClassName.Remove(index, subStringToRemove.Length);

        return ConvertCamelCaseToKababCase(targetUrl);
    }

    private static string ConvertCamelCaseToKababCase(string camelCase) {
        if (string.IsNullOrEmpty(camelCase)) {
            return string.Empty;
        }

        var result = new StringBuilder();
        for (int i = 0; i < camelCase.Length; i++) {
            char currentChar = camelCase[i];
            if (char.IsUpper(currentChar)) {
                if (i > 0 && !char.IsUpper(camelCase[i - 1])) {
                    result.Append('-');
                }

                result.Append(char.ToLower(currentChar));
            } else {
                result.Append(currentChar);
            }
        }

        return result.ToString();
    }

}
