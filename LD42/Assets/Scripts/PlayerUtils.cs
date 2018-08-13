using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : MonoBehaviour {


    public static bool isAlive = true;

    public static void Kill()
    {
        PlayerUtils.isAlive = false;
        Logger.LOG("PlayerUtils: Player Dead", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
