using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : MonoBehaviour {

    public static void Kill()
    {
        Logger.LOG("PlayerUtils: Player Dead", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
