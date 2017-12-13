using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField]
    private Vector3Int chunkSize = new Vector3Int(32, 32, 32);
    [SerializeField]
    private Vector3Int chunkCount = new Vector3Int(4, 4, 4);
    private Block[,,] map;
    private void Start()
    {
        //map = MapGenerator.Generate(null, chunkCount, chunkSize);
    }
}
