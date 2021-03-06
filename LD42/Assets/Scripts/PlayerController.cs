﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    bool SHOW_LOG = false;

    PlayerMotor motor;
    Rigidbody2D rb;
    float moveSpeed = 20.0f; // 20
    float jumpSpeed = 2.0f;
    float thresholdGroundedDistance = 0.2f;

    [SerializeField]
    LayerMask maskedLayers;

    [SerializeField]
    GameObject playerShootPoint, bullet;

    [SerializeField]
    CameraShake cameraShake;

    bool jumped;
    float jumpTime;

	// Use this for initialization
	void Start () {
		motor = GetComponent<PlayerMotor>();
		rb = GetComponent<Rigidbody2D>();

        jumped = false;
        PlayerUtils.isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (jumped && isGrounded() && ((Time.time - jumpTime) >= 0.5f) ) {
            jumped = false;
            if (cameraShake != null) {
                cameraShake.Shake(0.08f, 0.1f);
            }
        }

        // Movement
        float _xMov = Input.GetAxis("Horizontal") * moveSpeed;
        // float _xMov = moveSpeed; // Automove
        float _yMov = rb.velocity.y; // equals to player's current Y velocity

        if (Input.GetButton("Jump") && isGrounded()) {
            jumped = true;
            jumpTime = Time.time;
            // TODO: Don't jump too high
            _yMov += jumpSpeed; // initially it was jumpSpeed * -10 * time.deltatime
        }

        if (transform.position.y <= -5.0f) {
            PlayerUtils.Kill();
        }
        motor.move(new Vector2(_xMov, _yMov));

        // Shooting
        if (Input.GetKeyDown(KeyCode.X)) {
            if (cameraShake != null) {
                cameraShake.Shake(0.1f, 0.1f);
            }
            Instantiate(bullet, playerShootPoint.transform.position, playerShootPoint.transform.rotation);
        }
	}

    bool isGrounded()
    {
        // @TODO: Use LayerMasks to ignore certain layers
        float playerSize = GetComponent<BoxCollider2D>().size.y;
        Vector2 rayEmitPoint = new Vector2(transform.position.x, transform.position.y)
                                          + (-Vector2.up * playerSize);
        RaycastHit2D hit = Physics2D.Raycast(rayEmitPoint, -Vector2.up, 100);
        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - rayEmitPoint.y);
            if (distance <= thresholdGroundedDistance)
                return true;
        }
        return false;
    }
}
