using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHPBarControll : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHP;
    public float currentHP;
    GameObject innerBlood;
    void Start()
    {
        innerBlood =  GetChildWithName(gameObject, "Inner Blood");
    }

    // Update is called once per frame
    void Update()
    {
        innerBlood.GetComponent<Image>().fillAmount = currentHP / maxHP;
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

    public void SetPlayerMaxHP(float mhp)
    {
        maxHP = mhp;
        if(currentHP > maxHP)
            currentHP = maxHP;
    }
    
    public void SetPlayerHP(float hp)
    {
        currentHP = hp;
        if(hp > maxHP)
            currentHP = maxHP;
    }

    public void ResetPlayerHP()
    {
        currentHP = maxHP;
    }
}
