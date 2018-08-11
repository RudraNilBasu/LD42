using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    bool SHOW_LOG = false;
    void LOG(string msg) {
        if (SHOW_LOG && Settings.ENVIRONMENT == "DEVELOPMENT")
            Debug.Log(msg);
    }

    float startRadius = 5.0f;
    float currentRadius;

	// Use this for initialization
	void Start () {
        Debug.Log(Settings.ENVIRONMENT);
		currentRadius = startRadius;
        StartCoroutine(ReduceSpace());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentRadius <= 0.0f) {
            LOG("Player: DEAD");
            Destroy(gameObject);
        }

        LOG("Space: " + currentRadius);
	}

    void applyPickups(float amt)
    {
        LOG("Increasing Radius by: " + amt);
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
