using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{

    public static Block[,,] Generate(MapGeneratorSettings settings, Vector3Int mapSize)
    {
        Block[,,] map = new Block[mapSize.x, mapSize.y, mapSize.z];

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int z = 0; z < mapSize.z; z++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    if (y < x - 1)
                    {
                        map[x, y, z] = new Block(ResourcesManager.GetSubstance("stone"));
                    }
                    else
                    {
                        map[x, y, z] = new Block(ResourcesManager.GetSubstance("air"));
                    }
                }
            }
        }

        return map;
    }

}
