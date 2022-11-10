using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;
public class Monster3 : Monster.Monster {
    void Awake() {
		this.defaultStart();
		this.HP = 100;
	}
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
        this.stateUpdate();
         Vector3.Distance(this.player.transform.position,this.gameObject.transform.position);
	}
}
