using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    bool SHOW_LOG = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        Logger.LOG("Destroyer: Consumed " + coll.gameObject.name, SHOW_LOG);
        Destroy(coll.gameObject);
    }
}
