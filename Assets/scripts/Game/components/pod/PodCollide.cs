using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodCollide : MonoBehaviour {
    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }




}
