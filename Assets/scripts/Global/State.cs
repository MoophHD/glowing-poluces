using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
	private static State _instance;
	public static State instance {
		get {
			return _instance;
		}
	}

	public int score {get;set;}

	void Awake() {
		score = 0;

		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
	}
}
