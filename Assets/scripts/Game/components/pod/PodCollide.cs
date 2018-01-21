using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodCollide : MonoBehaviour {
    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "pod") {
            GameEvents.dispatch("POD_CONTACT");
            // rb.AddForce (pushRight * speed);
        }
    }


}
