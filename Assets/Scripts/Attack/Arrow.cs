using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    // Start is called before the first frame update
    public bool isShooted { get; set; }
    private Rigidbody mRigid;
    private bool isPlayerGetDamage;
    private AudioSource audioController;
    public void faceToPlayer(GameObject player) => this.gameObject.transform.LookAt(player.transform);
    public void velocityInit(GameObject player) {
        this.mRigid.constraints = RigidbodyConstraints.None;
        this.mRigid.constraints = RigidbodyConstraints.FreezeRotation;
        this.mRigid.velocity = (Vector3.Normalize((player.transform.position - this.gameObject.transform.position + Vector3.up)) * 15);

    }
    void Start() {
        this.isShooted = false;
        this.isPlayerGetDamage = false;
        this.mRigid = this.gameObject.GetComponent<Rigidbody>();
        this.audioController = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (this.isPlayerGetDamage && this.mRigid.velocity.sqrMagnitude < 0.01f)
            this.mRigid.constraints = RigidbodyConstraints.FreezeAll;
        if (this.gameObject.transform.parent && this.gameObject.transform.parent.tag == "Player")
            this.gameObject.transform.localPosition = Vector3.up * 0.7f;
    }
    void OnTriggerEnter(Collider other) {
        if (!this.isShooted)
            return;

        if (other.tag == "Player" && !this.isPlayerGetDamage) {
            this.audioController.Play();
            this.gameObject.transform.SetParent(other.gameObject.transform, true);

            // Player get damage
            if (other.gameObject.TryGetComponent<ManControl>(out ManControl player))
            {
                player.AttackByMonster(50);
            }
            this.isPlayerGetDamage = true;
            this.mRigid.drag = 20f;
        }

    }
}
