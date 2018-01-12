using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour {
    private Rigidbody2D rb;
    private float force = 10f;
    private LineRenderer lr;


    private bool swiping = false;
    private float radius = 1.5f;
    private Vector3 direction = Vector3.zero;
    private Vector3 anchor;
    // private Vector3 swipeStart = Vector3.zero;
    // private Vector3 swipeFinish = Vector3.zero;
    
    void DrawLine(Vector3 start, Vector3 end, Color cl)
    {
        GameObject myLine = new GameObject();
        myLine.transform.SetParent(GetComponent<Transform>());
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.sortingOrder = 1;
		lr.startColor = cl;
		lr.endColor = cl;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        // DrawLine(Vector3.zero, Vector3.zero, Color.red);
        anchor = GetComponent<Transform>().position;
        DrawLine(anchor, anchor, Color.red);
        
    }

    void OnEnable () {
        GameEvents.listen("UNFREEZE", handleUnfreeze);
        
    }

    void OnDisable  () {
        GameEvents.stopListening("UNFREEZE", handleUnfreeze);
    }

    void handleUnfreeze () {
        jump();
        hideLine();
    }

    void jump() {
        rb.AddForce(new Vector2(direction.x, direction.y) * force, ForceMode2D.Impulse);
    }

    void hideLine() {
        GameObject.Destroy(lr);
    }

    void Update() {
        // PRESS
        if (Input.GetMouseButtonDown(0)) {
            if (!swiping) {
                swiping = true;
            }
        }
        //HOLD
        if (swiping) {
            Vector3 finPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finPoint.z = 0;
            // print(absolutePoint);
            // direction = absolutePoint.normalized;
            // Vector3 clampedPoint = direction * radius;

            direction = (finPoint - anchor).normalized;
      
            // lr.SetPosition(1, (direction + anchor) * radius );
            lr.SetPosition(1, Vector3.ClampMagnitude(direction, radius)+ anchor );
        }

        if (Input.GetMouseButtonUp(0)) {
            swiping = false;
        }
    }
}