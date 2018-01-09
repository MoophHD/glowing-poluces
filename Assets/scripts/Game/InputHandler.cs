using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
	void Update () {
		if ( Input.touchCount > 0 || Input.GetMouseButtonDown(0) ) {
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Vector3 clickPoint = ray.GetPoint(0f);

            EventManager.dispatch("TAP");
        }
	}
}
