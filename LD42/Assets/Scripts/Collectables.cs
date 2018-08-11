using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    bool SHOW_LOG = true;

    float radiusAdded = 5.0f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player") {
            Logger.LOG(gameObject.name + ": Collected. radius gained: " + radiusAdded, SHOW_LOG);
            GameObject player = coll.gameObject;
            player.GetComponent<SpaceController>().applyPickups(radiusAdded);
            Destroy(gameObject);
        }
    }
}
