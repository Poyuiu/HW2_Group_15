using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Monster {
    public class Monster : MonoBehaviour {
        public GameObject player;
        public ParticleSystem bloodSplash;
        public float detectPlayerDistance;

        protected bool isMove;
        protected bool isAtk;
        protected bool isDie;
        protected bool isAtkToPlayer;
        protected Animator mAnimator;
        protected int HP;
        protected Vector3 moveDir;
        protected Rigidbody mRigidbody;
        protected NavMeshAgent mNavigation;
        protected AnimatorStateInfo mAnimatorState;

        private bool isDestroy;
        protected void defaultStart() {
            this.isMove = false;
            this.isAtk = false;
            this.isDie = false;
            this.isDestroy = false;
            this.isAtkToPlayer = false;
            this.mAnimator = this.gameObject.GetComponent<Animator>();
            this.mRigidbody = this.gameObject.GetComponent<Rigidbody>();
            this.mNavigation = this.gameObject.GetComponent<NavMeshAgent>();

            this.mNavigation.SetDestination(this.player.transform.position);
            this.mNavigation.isStopped = true;
        }
        public void atkByPlayer() {
            this.bloodSplash.Play();
            this.HP -= 10;
            Invoke("stopBloodSplash", 0.6f);
        }
        private void stopBloodSplash() => this.bloodSplash.Stop();
        protected void stateUpdate() {
            this.mNavigation.isStopped = this.mNavigation.remainingDistance > this.detectPlayerDistance;
            this.mNavigation.SetDestination(this.player.transform.position);
            this.isMove = this.mNavigation.velocity.sqrMagnitude > 0.01;
            this.isDie = this.HP <= 0;
            this.isAtk = this.mNavigation.stoppingDistance >= this.mNavigation.remainingDistance;
            // TODO: Fix isAtk bug. (isATK = false but in atk animation)
            if (this.isAtk) {
                this.isMove = false;
                // Get attack animation state
                this.mAnimatorState = this.mAnimator.GetCurrentAnimatorStateInfo(0);
            }

            this.mAnimator.SetBool("isMove", this.isMove);
            this.mAnimator.SetBool("isAtk", this.isAtk);
            this.mAnimator.SetBool("isDie", this.isDie);
            if (this.isDie) {
                this.isMove = false;
                this.isAtk = false;
                if (!this.isDestroy)
                    Destroy(this.gameObject, 3f);
                this.isDestroy = true;
            }
        }
    }
}