using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.Serialization;

[System.Serializable]
public class Substance : ResourceObject
{
    [JsonIgnore]
    private Material textureMaterial;
    [JsonProperty]
    private string textureMaterialName;
    public Substance(string name, string textureName)
    {
        this.name = name;
        this.textureMaterialName = textureName;
    }
    [OnDeserialized]
    internal void OnDeserialization(StreamingContext context)
    {
        textureMaterial = ResourcesManager.GetMaterial(textureMaterialName);
    }

}