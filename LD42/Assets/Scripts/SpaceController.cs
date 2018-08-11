using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    bool SHOW_LOG = false;

    float startRadius = 5.0f;
    float currentRadius;

	// Use this for initialization
	void Start () {
		currentRadius = startRadius;
        StartCoroutine(ReduceSpace());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentRadius <= 0.0f) {
            PlayerUtils.Kill();
        }

        Logger.LOG("Space: " + currentRadius, SHOW_LOG);
	}

    public void applyPickups(float amt)
    {
        Logger.LOG("Increasing Radius by: " + amt, SHOW_LOG);
        currentRadius += amt;
    }

    IEnumerator ReduceSpace()
    {
        while (currentRadius > 0.0f) {
            yield return new WaitForSeconds(1.0f);
            currentRadius -= 0.5f;
        }
    }
}
