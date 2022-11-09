using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	// Start is called before the first frame update
	public bool isShooted { get; set; }
	private Rigidbody mRigid;
	public void faceToPlayer(GameObject player) => this.gameObject.transform.LookAt(player.transform);
	public void velocityInit() {
		this.mRigid.constraints = RigidbodyConstraints.None;
        this.mRigid.constraints = RigidbodyConstraints.FreezeRotation;
		this.mRigid.AddRelativeForce(new Vector3(0f, 0f, 500f));
	}
	void Start() {
		this.isShooted = false;
		this.mRigid = this.gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		if (!this.isShooted)
			return;

	}
}
