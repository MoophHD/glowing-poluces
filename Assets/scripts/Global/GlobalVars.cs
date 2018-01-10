using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour {
	private static GlobalVars _instance;
	public static GlobalVars Instance {
        get {
            if (_instance == null) {
                GameObject go = GameObject.Find("Global");
                if (go == null)
                    go = new GameObject("Global");
                go.AddComponent<GlobalVars>();
                
            }

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

     [HideInInspector]public Vector3 InitialGravityScale;


	void Awake() {
        InitialGravityScale = Physics2D.gravity;

        _MinCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        _MaxCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        _ScreenHeight = MaxCameraBounds.y - MinCameraBounds.y;

		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
	}
}
