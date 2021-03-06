﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    bool SHOW_LOG = false;

    float startRadius = 50.0f;
    float currentRadius;

    // temp space representer
    // @TODO: Please use a Shader to represent it better
    // A Good way will be to blur / darken everything outside
    // and make the radius bigger
    [SerializeField]
    GameObject spaceGO;

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

        // TODO: Better way of this
        spaceGO.transform.localScale = new Vector3(currentRadius, currentRadius, 1.0f);
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
            yield return new WaitForSeconds(0.5f);
            currentRadius -= 0.5f;
        }
    }
}
