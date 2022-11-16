using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureGen1 : MonoBehaviour
{
    public GameObject curePrefab;
    public Terrain terrain;

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;

    // Start is called before the first frame update
    void Start()
    {
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        for(int i=0; i < 20; i++)
        {
            Generate();
        }
    }

    void Generate()
    {
        float randX = Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float Y = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

        Instantiate(curePrefab, new Vector3(randX, Y, randZ), Quaternion.identity);
    }
}
