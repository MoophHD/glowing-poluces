using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
	void Update () {
        print(Input.GetMouseButtonDown(0));
		if ( Input.touchCount > 0 || Input.GetMouseButtonDown(0) ) {
            print('1');
        }
	}
}
