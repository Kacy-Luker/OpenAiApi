using Microsoft.Extensions.Options;
using OpenAiApi.Endpoints.Interfaces;

namespace OpenAiApi.Endpoints;
public class ModelsEndpoint : AbstractEndpoint, IModelsEndpoint {
    public ModelsEndpoint(IOptions<Configurations> configurationsOptions) : base(configurationsOptions.Value) { }
}
