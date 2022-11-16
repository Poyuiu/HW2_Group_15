using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureGen1 : MonoBehaviour
{
    public GameObject curePrefab;
    private int prefabCount;
    public Terrain terrain;
    public GameObject chan;

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

        // for(int i=0; i < 20; i++)
        // {
        //     Generate();
        // }
    }

    void Generate()
    {
        float randX = Random.Range(chan.transform.position.x-20, chan.transform.position.x+20);
        float randZ = Random.Range(chan.transform.position.z-20, chan.transform.position.z+20);
        float Y = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

        Instantiate(curePrefab, new Vector3(randX, Y, randZ), Quaternion.identity);
    }

    private void Update()
    {
        if (prefabCount < 5)
        {
            Generate();
        }

        GameObject[] findPrefab = GameObject.FindGameObjectsWithTag("cure");
        prefabCount = findPrefab.Length;
    }
}
