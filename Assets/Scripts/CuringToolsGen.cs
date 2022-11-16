using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuringToolsGen : MonoBehaviour
{
    public GameObject curePrefab;
    private int prefabCount;
    public GameObject chan;
    private void Start()
    {
        prefabCount = 0;
    }
    private void Update()
    {
        if (prefabCount < 10)
        {
            float x = chan.transform.position.x;
            float z = chan.transform.position.z;
            Vector3 rdPosition =
                new(Random.Range(-3, 4) + x, 0, Random.Range(-3, 4) + z);
            Instantiate(curePrefab, rdPosition, Quaternion.identity);
        }

        GameObject[] findPrefab = GameObject.FindGameObjectsWithTag("cure");
        prefabCount = findPrefab.Length;
    }
}
