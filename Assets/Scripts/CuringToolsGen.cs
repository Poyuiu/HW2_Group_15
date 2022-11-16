using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuringToolsGen : MonoBehaviour
{
    public GameObject curePrefab;
    private int prefabCount;
    private GameObject chan;
    private void Start()
    {
        prefabCount = 0;
        chan = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (prefabCount < 1)
        {
            float x = chan.transform.position.x;
            float y = chan.transform.position.y;
            float z = chan.transform.position.z;
            Vector3 rdPosition =
                new(Random.Range(-3, 4) + x, y, Random.Range(-3, 4) + z);
            Instantiate(curePrefab, rdPosition, Quaternion.identity);
        }

        GameObject[] findPrefab = GameObject.FindGameObjectsWithTag("cure");
        prefabCount = findPrefab.Length;
    }
}
