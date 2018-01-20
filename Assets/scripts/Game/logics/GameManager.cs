using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject winMenu;
    void OnEnable () {
        GameEvents.listen("UNFREEZE", enableGravity);
        GameEvents.listen("REPLAY", hideWinMenu);
        GameEvents.listen("POD_CONTACT", showWinMenu);
        
    }

    void OnDisable  () {
        GameEvents.stopListening("UNFREEZE", enableGravity);
        GameEvents.stopListening("REPLAY", hideWinMenu);
        GameEvents.stopListening("POD_CONTACT", showWinMenu);
    }

    void Start() {
        Physics2D.gravity = Vector3.zero;
    }

    void enableGravity() {
        Physics2D.gravity = GlobalVars.Instance.InitialGravityScale;
    }

    void showWinMenu() {
        winMenu.SetActive(true);
    }

    void hideWinMenu() {
        winMenu.SetActive(false);
    }
}