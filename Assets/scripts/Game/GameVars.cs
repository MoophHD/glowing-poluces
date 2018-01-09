using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVars : MonoBehaviour {
    private static GameVars _instance;
    public static GameVars Instance {
        get {
            return _instance;
        }
    }

    private float _ScreenHeight;
    public float ScreenHeight {
        get {
            return _ScreenHeight;
        }
    }

    private Vector2 _MaxCameraBounds;
    public Vector2 MaxCameraBounds {
        get {
            return _MaxCameraBounds;
        }
    }

    private Vector2 _MinCameraBounds;
    public Vector2 MinCameraBounds {
        get {
            return _MinCameraBounds;
        }
    }
    
    void Awake() {
    _instance = this;

    _MinCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
    _MaxCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    _ScreenHeight = MaxCameraBounds.y - MinCameraBounds.y;
	}
}