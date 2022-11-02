using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;
public class Monster2 : Monster.Monster {
	private Vector3 atkAngleFix;
	private bool isAtkAngleFix;
	void Start() {
		this.defaultStart();
		this.HP = 100;
		this.atkAngleFix = new Vector3(0f, 130f, 0f);
		this.isAtkAngleFix = false;
	}

	// Update is called once per frame
	void Update() {
		this.stateUpdate();
		if (this.isAtk && !this.isAtkAngleFix) {
			this.isAtkAngleFix = true;
            this.gameObject.transform.Rotate(this.atkAngleFix);
		}

	}
}
