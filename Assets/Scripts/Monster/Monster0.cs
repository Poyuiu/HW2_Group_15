using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;

public class Monster0 : Monster.Monster {

    private float atkAnimationTime;
    private bool isPlayerGetDamage;
    void Awake() {
        
        this.isPlayerGetDamage = false;
        this.HP = 100;
        this.defaultStart();
    }
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown("space"))
        {
            this.atkByPlayer();
        }
    }
}
