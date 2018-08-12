using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    int xOffset = 6;

	// Use this for initialization
	void Start () {
		if (target == null) {
            Debug.LogError("CameraController: No Camera Found");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null) return;
		transform.position = new Vector3(target.position.x + xOffset, 0, -10);
	}
}
