using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    PlayerMotor motor;
    Rigidbody2D rb;
    float moveSpeed = 20.0f;
    float jumpSpeed = 2.0f;
    float thresholdGroundedDistance = 0.2f;

    [SerializeField]
    LayerMask maskedLayers;

	// Use this for initialization
	void Start () {
		motor = GetComponent<PlayerMotor>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float _xMov = Input.GetAxis("Horizontal") * moveSpeed;
        float _yMov = rb.velocity.y; // equals to player's current Y velocity

        if (Input.GetButton("Jump") && isGrounded()) {
            // TODO: Don't jump too high
            _yMov += jumpSpeed; // initially it was jumpSpeed * -10 * time.deltatime
        }

        motor.move(new Vector2(_xMov, _yMov));
	}

    bool isGrounded()
    {
        // @TODO: Use LayerMasks to ignore certain layers
        float playerSize = GetComponent<BoxCollider2D>().size.y;
        Vector2 rayEmitPoint = new Vector2(transform.position.x, transform.position.y)
                                          + (-Vector2.up * playerSize);
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 100, maskedLayers);
        // RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y)
                                                     // + (-Vector2.up * playerSize), -Vector2.up, 100);
        RaycastHit2D hit = Physics2D.Raycast(rayEmitPoint, -Vector2.up, 100);
        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - rayEmitPoint.y);
            if (distance <= thresholdGroundedDistance)
                return true;
        }
        return false;
    }
}
