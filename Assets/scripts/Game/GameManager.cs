using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMamager : MonoBehaviour {
    void OnEnable () {
        EventManager.listen("SHOT_SUCCESS", setStuff);
        EventManager.listen("SHOT_FAILURE", lose);
        
    }

    void OnDisable  () {
        EventManager.stopListening("SHOT_SUCCESS", setStuff);
        EventManager.stopListening("SHOT_FAILURE", lose);
    }

    void setStuff() {
        
    }

    void lose() {
        
    }

}