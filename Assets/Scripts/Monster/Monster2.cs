using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;
public class Monster2 : Monster.Monster {
    public Animator bowAnimator;
    public GameObject holdingArrow;
    private float atkAnimationTime;
    void Awake() {
        this.defaultStart();
        this.HP = 100;

    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        this.stateUpdate();
        if (!this.holdingArrow.activeSelf && this.isAtk)
            this.holdingArrow.SetActive(true);
        else if (this.holdingArrow.activeSelf && !this.isAtk)
            this.holdingArrow.SetActive(false);
        if (this.isAtk) {
            this.atkAnimationTime = this.mAnimatorState.normalizedTime % 1;
            this.bowAnimator.SetBool("isAtk", this.atkAnimationTime > 0.64);
            Debug.Log(this.atkAnimationTime);
        } else
            this.bowAnimator.SetBool("isAtk", false);
    }
}
