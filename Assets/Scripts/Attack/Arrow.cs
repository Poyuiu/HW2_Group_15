using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	// Start is called before the first frame update
	public bool isShooted { get; set; }
	private Rigidbody mRigid;
	private bool isPlayerGetDamage;
	public void faceToPlayer(GameObject player) => this.gameObject.transform.LookAt(player.transform);
	public void velocityInit() {
		this.mRigid.constraints = RigidbodyConstraints.None;
		this.mRigid.constraints = RigidbodyConstraints.FreezeRotation;
		this.mRigid.AddRelativeForce(new Vector3(0f, 0f, 500f));
	}
	void Start() {
		this.isShooted = false;
		this.isPlayerGetDamage = false;
		this.mRigid = this.gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		if (this.isPlayerGetDamage && this.mRigid.velocity.sqrMagnitude < 0.01f)
			this.mRigid.constraints = RigidbodyConstraints.FreezeAll;
	}
	void OnTriggerEnter(Collider other) {
		if (!this.isShooted)
			return;
		if (other.tag == "Player" && !this.isPlayerGetDamage) {
			this.isPlayerGetDamage = true;
			this.mRigid.drag = 20f;
			this.gameObject.transform.SetParent(other.gameObject.transform, true);
			// Player get damage
		}
	}
}
