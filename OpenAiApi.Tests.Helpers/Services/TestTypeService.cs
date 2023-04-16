namespace OpenAiApi.Tests.Helpers.Services;

public class TestType {
    public TestTypes Type { get; set; }

    public void GetTypeOfGetTest(string? id, string? props) {
        if (id is null && props is null) {
            Type = TestTypes.GetList;
        } else if (id is not null && props is null) {
            Type = TestTypes.GetId;
        } else if (id is not null && props is not null) {
            Type = TestTypes.GetIdProp;
        }
    }
}
