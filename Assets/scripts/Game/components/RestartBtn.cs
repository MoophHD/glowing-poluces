using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RestartBtn : MonoBehaviour {
    private Button yourButton;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(restart);
    }

    void restart()
    {
        GameEvents.dispatch("REPLAY");
    }
    
}
