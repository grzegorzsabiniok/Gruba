using Newtonsoft.Json;

[System.Serializable]
public class ResourceObject
{
    [JsonProperty]
    protected string name;
    public string GetName()
    {
        return name;
    }
}