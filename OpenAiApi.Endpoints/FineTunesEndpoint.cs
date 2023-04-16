using Microsoft.Extensions.Options;
using OpenAiApi.Endpoints.Interfaces;

namespace OpenAiApi.Endpoints;
public class FineTunesEndpoint : AbstractEndpoint, IModelsEndpoint {
    public FineTunesEndpoint(IOptions<Configurations> configurationsOptions) : base(configurationsOptions.Value) { }
}
