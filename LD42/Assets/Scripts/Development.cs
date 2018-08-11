using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AClockworkBerry;

public class Development : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ScreenLogger.Instance.ShowLog = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T)) {
            ScreenLogger.Instance.ShowLog = !ScreenLogger.Instance.ShowLog;
        }
	}
}
