using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;

public class Monster1 : Monster.Monster {

    public AudioClip atkAudio;
    private bool isAtkAudioPlayed = false;
    private float atkAnimationTime;
    private bool isPlayerGetDamage;
    void Awake() {

        this.isPlayerGetDamage = false;
        this.HP = 50;
        this.defaultStart();
    }
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        this.stateUpdate();

        if (this.isAtk && this.mAnimatorState.IsName("Attack01")) {
            this.atkAnimationTime = this.mAnimatorState.normalizedTime % 1;
            this.isAtkToPlayer = this.atkAnimationTime > 0.5 && this.atkAnimationTime < 0.625;
            if (this.atkAnimationTime < 0.4)
                this.isPlayerGetDamage = false;
            if (this.atkAnimationTime > 0.5 && !this.isAtkAudioPlayed && !this.audioController.isPlaying) {
                this.audioController.loop = false;
                this.isAtkAudioPlayed = true;
                this.audioController.clip = this.atkAudio;
                this.audioController.Play();
            }
            if (this.atkAnimationTime > 0.98) {
                this.audioController.Stop();
                this.isAtkAudioPlayed = false;
            }

        }
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && this.isAtkToPlayer && !this.isPlayerGetDamage) {
            this.isPlayerGetDamage = true;
            // Player get damage
            if (other.gameObject.TryGetComponent<ManControl>(out ManControl mc)) {
                mc.AttackByMonster();
            }
        }
    }
}
