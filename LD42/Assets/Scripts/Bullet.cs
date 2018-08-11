using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    bool SHOW_LOG = false;
    Rigidbody2D rb;

    private float speed = 30.0f;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		Logger.LOG("" + rb.velocity.x + " , " + rb.velocity.y, SHOW_LOG);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            return;
        // TODO: Reverse the direction
        rb.velocity = Vector2.right * -1 * speed;
        // Destroy(gameObject);
    }
}
