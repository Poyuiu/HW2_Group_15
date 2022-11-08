using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Monster;

public class HealthBarControl : MonoBehaviour
{
    public Monster.Monster monster;
    GameObject cameraToLookAt;
    // Start is called before the first frame update
    int maxHP;
    int currentHP;
    GameObject innerBlood;
    void Start()
    {
        maxHP = monster.GetHP();
        innerBlood =  GetChildWithName(gameObject, "Inner Blood");
    }

    // Update is called once per frame
    void Update()
    {
        cameraToLookAt = GameObject.Find("Main Camera");
        currentHP = monster.GetHP();
        innerBlood.GetComponent<Image>().fillAmount = (float)currentHP / (float)maxHP;
        transform.position = monster.transform.position + Vector3.up*1.5f;
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        transform.LookAt(cameraToLookAt.transform); 
    }

    GameObject GetChildWithName(GameObject obj, string name) {
        Transform trans = obj. transform;
        Transform childTrans = trans. Find(name);
        if (childTrans != null) {
            return childTrans. gameObject;
        } else {
            return null;
        }
    }

    public void ChangeCameraTo(GameObject newCamera)
    {
        cameraToLookAt = newCamera;
    }
}
