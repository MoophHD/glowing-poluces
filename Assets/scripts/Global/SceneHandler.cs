using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    void toTheMenu() {
        SceneManager.LoadScene("scene");
    }
}