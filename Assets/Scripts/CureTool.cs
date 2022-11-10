using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureTool : MonoBehaviour
{
    public float TimetoLive = 5f;
    private void Update()
    {
        Destroy(gameObject, TimetoLive);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
