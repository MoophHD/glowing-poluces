using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour {

    private float initialRotation;
    private float force = 10f;

    private Rigidbody2D rb;
    private Transform tr;
    private LineRenderer lr;

    public GameObject arrow;
    public Transform arrowPivotTr;

    private bool swiping = false;
    private float radius = 1.5f;
    private Vector3 direction = Vector3.zero;
    private Vector3 anchor;
    // private Vector3 swipeStart = Vector3.zero;
    // private Vector3 swipeFinish = Vector3.zero;

    private Vector3 minVector;
    private Vector3 maxVector;

    void Start() {
        minVector = Vector3.left;
        maxVector = Vector3.right;

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        initialRotation = tr.eulerAngles.z; //unity uses inversed degrees

        // DrawLine(Vector3.zero, Vector3.zero, Color.red);
        anchor = tr.position;
        DrawLine(anchor, anchor, Color.red);
    }


    // HANDLE POD x POD COLLISION
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "pod") {
            GameEvents.dispatch("POD_CONTACT");
        }
    }
    
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

    void OnEnable () {
        GameEvents.listen("UNFREEZE", handleUnfreeze);
    }

    void OnDisable  () {
        GameEvents.stopListening("UNFREEZE", handleUnfreeze);
    }

    void handleUnfreeze () {
        release();
        hideLine();
    }

    void release() {
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

            direction = (finPoint - anchor).normalized;
            float deg = (float)((Mathf.Atan2(direction.x, direction.y) / Mathf.PI) * 180f);

            if (deg > 0) deg = -180 - (180-deg); // @_@

            arrowPivotTr.rotation = Quaternion.Euler(0, 0, -deg);

            lr.SetPosition(1, Vector3.ClampMagnitude(direction, radius)+ anchor );
        }

        if (Input.GetMouseButtonUp(0)) {
            swiping = false;
        }
    }
}

