using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager singleton;
    [SerializeField]
    private Material[] materialsPrefabs;

    private Dictionary<string, Material> materials = new Dictionary<string, Material>();
    private Dictionary<string, Substance> blocksMaterials = new Dictionary<string, Substance>();

    private void Awake()
    {
        singleton = this;
        foreach (Material material in materialsPrefabs)
        {
            materials.Add(material.name, material);
        }
    }
    private void Start()
    {
        ResourcesLoader loader = new ResourcesLoader("\\Data\\");
        blocksMaterials = loader.Load<Substance>("Blocks\\");
        print(blocksMaterials["air"].GetName());
    }
    public static Material GetMaterial(string name)
    {
        if (singleton.materials.ContainsKey(name))
        {
            return singleton.materials[name];
        }
        else
        {
            return null;
        }
    }
    public static Substance GetSubstance(string name)
    {
        if (singleton.materials.ContainsKey(name))
        {
            return singleton.blocksMaterials[name];
        }
        else
        {
            return null;
        }
    }
}
