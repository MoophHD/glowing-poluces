using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class State : MonoBehaviour {
	private static State _instance;
	public static State Instance {
	get {
		if (_instance == null) {
			GameObject go = GameObject.Find("Global");
			if (go == null)
				go = new GameObject("Global");

				go.AddComponent<State>();

		}

		return _instance;
	}
	}

	private int _lvl;
	public int lvl {
		get {
			return _lvl;
		}
		set {
			if (_lvl != value) {
				loadLvlInfo();
			}
			_lvl = value;
		}
	}


	public class LvlInfo {
		public Tile[] tiles;
	}

	void loadLvlInfo() {
		string path = Application.streamingAssetsPath + "/lvlinfo.json";
		string jsonString = File.ReadAllText(path);

		lvlInfo = JsonUtility.FromJson<LvlInfo>(jsonString);
	}

	public static LvlInfo lvlInfo {get; set;}

	public bool isPodActive {get;set;}

	void Awake() {
		//temp 
		loadLvlInfo();
		isPodActive = false;

		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
	}
}
