using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    void OnEnable () {
        GameEvents.listen("UNFREEZE", enableGravity);
        
    }

    void OnDisable  () {
        GameEvents.stopListening("UNFREEZE", enableGravity);
    }

    void Start() {
        Physics2D.gravity = Vector3.zero;
    }

    void enableGravity() {
        Physics2D.gravity = GlobalVars.Instance.InitialGravityScale;
    }
}