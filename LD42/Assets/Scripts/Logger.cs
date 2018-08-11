using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour {

    public static void LOG(string msg, bool SHOW_LOG = false) {
        if (SHOW_LOG && Settings.ENVIRONMENT == "DEVELOPMENT")
            Debug.Log(msg);
    }
}
