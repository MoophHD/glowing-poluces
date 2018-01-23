using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinMenu : MonoBehaviour {
    private Button replayBtn;
    private Button nextBtn;

    void Start() {
        Transform tr = GetComponent<Transform>();
        replayBtn = tr.Find("Replay").GetComponent<Button>();
        nextBtn = tr.Find("Next").GetComponent<Button>();

        replayBtn.onClick.AddListener(displatchReplay);
        nextBtn.onClick.AddListener(displatchNext);
    }

    void displatchReplay() {
        GameEvents.dispatch("REPLAY");
    }

    void displatchNext() {
        GameEvents.dispatch("MENU_NEXT");
    }

    void unfreeze()
    {
        GameEvents.dispatch("ONTO_NEXT_LEVEL");
    }
    
}
