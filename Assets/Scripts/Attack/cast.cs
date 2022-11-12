using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cast : MonoBehaviour {
    public GameObject magicCircleObject;
    public ParticleSystem burstParticle;
    public AnimationCurve magicCircleAngleCurve;

    private float magicCircleRadius = 50f;
    private float burstDelay = 1.5f;
    private float burstStopDelay = 2.5f;
    private Light magicCircle;
    private Vector3 magicCircleRotate = new Vector3(0f, 0f, 1.5f);
    private float spawnTime;

    private bool isBurst = false;
    private bool isAtkDetect = false;
    void Start() {
        this.magicCircle = this.magicCircleObject.GetComponent<Light>();
        this.spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time - this.spawnTime > this.burstDelay && !this.isBurst) {
            this.burstParticle.Play();
            this.isBurst = true;
        }
        if (Time.time - this.spawnTime > this.burstDelay + 0.1f)
            this.isAtkDetect = true;
        if (Time.time - this.spawnTime > this.burstStopDelay)
            this.burstParticle.Stop();
        if (Time.time - this.spawnTime > this.burstStopDelay + 0.2f)
            Destroy(this.gameObject);
    }
    void FixedUpdate() {

        this.magicCircleObject.transform.Rotate(this.magicCircleRotate);
        if (this.magicCircle.spotAngle < this.magicCircleRadius)
            this.magicCircle.spotAngle = magicCircleRadius * magicCircleAngleCurve.Evaluate(Time.time - this.spawnTime);
    }
    void OnTriggerStay(Collider other) {
        if (this.isAtkDetect) {
            this.isAtkDetect = false;
            // Player get damage
        }
    }
}
