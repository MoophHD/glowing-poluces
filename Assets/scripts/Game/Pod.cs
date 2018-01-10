using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour {
    private float force;
    private LineRenderer lr;

    private Vector3 swipeStart;
    private Vector3 swipeFinish;

    void DrawLine(Vector3 start, Vector3 end, Color cl)
    {
        GameObject myLine = new GameObject();
        myLine.transform.SetParent(GetComponent<Transform>());
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = cl;
		lr.endColor = cl;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    void Start() {
        DrawLine(Vector3.zero, Vector3.zero, Color.red);
    }

    void Update() {
        // SWIPE START
        if (Input.touchCount == 1) {
            swipeStart = Input.GetTouch(0).position;
            lr.SetPosition(0, swipeStart);
        }

        // SWIPING

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            swipeFinish = Input.GetTouch(0).position;
            lr.SetPosition(1, swipeFinish);
            
        }
    }
}