using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    private Transform tr;
    private Vector3 initPos;


    private float force = 12.5f;

    // floating after jump
    private float fallMultiplier = 2.25f;
	private float lowJumpMultiplier = 1.5f;

    

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        initPos = tr.position;

        rb.gravityScale = 0;
    }

    void OnEnable () {
        EventManager.listen("TAP", jump);
        EventManager.listen("SHOT_SUCCESS", reset);
    }

    void OnDisable  () {
        EventManager.stopListening("TAP", jump);
        EventManager.stopListening("SHOT_SUCCESS", reset);
    }

    void jump() {
        rb.gravityScale = 1;

        rb.velocity = Vector2.up * force;
        Invoke("dispatchShot", 1f);
    }
    void dispatchShot () {
        EventManager.dispatch("SHOT_SUCCESS");
    }

    void reset() {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        
        tr.position = initPos;
    }

    void Update() {

        // SMOOTH LANDING

        if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && Input.GetButton("Jump")) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
    }
}
