using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blocks : MonoBehaviour {

    public bool isBreakable = true;

    private float breakStartTime, breakEndTime, breakTime = 1.5f;
    private bool startBreaking, isBroken;

    bool SHOW_LOG = false;

	// Use this for initialization
	void Start () {
		startBreaking = false;
        isBroken = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isBroken)
            return;
		if (startBreaking) {
            float timeDiff = Time.time - breakStartTime;
            Logger.LOG(gameObject.name + ": Time elapsed: " + timeDiff, SHOW_LOG);
            if (timeDiff >= breakTime) {
                Logger.LOG(gameObject.name + ": Broken.", SHOW_LOG);
                isBroken = true;
                // TODO: Better stuff with this
                transform.DOMoveY(-7, 2);
                Destroy(gameObject, 5);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (startBreaking || isBroken)
            return;
        if (coll.gameObject.tag == "Player") {
            startBreaking = true;
            Logger.LOG(gameObject.name + " has started breaking", SHOW_LOG);
            breakStartTime = Time.time;
        }
    }
}
