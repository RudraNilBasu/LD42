using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    Vector2 velocity;
    Rigidbody2D rb;

    float lowJumpMultiplier = 2f;
    float fallMultiplier = 2.5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
		velocity = new Vector2(0, 0);
	}

	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = velocity;

        // Better jump
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
	}

    public void move(Vector2 _velocity) {
        velocity = _velocity;
    }
}
