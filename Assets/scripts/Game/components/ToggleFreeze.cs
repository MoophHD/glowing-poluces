using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToggleFreeze : MonoBehaviour {
    private Button yourButton;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(unfreeze);
    }

    void unfreeze()
    {
        GameEvents.dispatch("UNFREEZE");
    }
    
}
