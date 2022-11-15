using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            if (other.gameObject.TryGetComponent<Monster1>(out Monster1 sc1))
            {
                sc1.atkByPlayer();
            }
            else if (other.gameObject.TryGetComponent<Monster2>(out Monster2 sc2))
            {
                sc2.atkByPlayer();
            }
            else if (other.gameObject.TryGetComponent<Monster3>(out Monster3 sc3))
            {
                sc3.atkByPlayer();
            }
        }
    }
}
