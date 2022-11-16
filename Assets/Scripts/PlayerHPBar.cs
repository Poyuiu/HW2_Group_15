using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int HP) {
        slider.maxValue = HP;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
