using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodControl : MonoBehaviour {
    private bool active = false;
    private Vector3 clickPos;
    public GameObject arrowContainer;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
        clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(clickPos, clickPos);
        RaycastHit2D hit;

        if (active) {
            for (int i = 0; i < hits.Length; i++) {
                hit = hits[i];

                if (hit.transform.tag == "pod_active_rad") return;
            }

            active = false;
            transform.gameObject.GetComponent<Pod>().deactivateControl();
            
        } else {
            for (int i = 0; i < hits.Length; i++) {
                hit = hits[i];

                if(hit.transform.tag == "pod_trigger_rad") {
                    if (hit.transform.parent != transform) return;

                    transform.gameObject.GetComponent<Pod>().activateControl();

                    arrowContainer.SetActive(true);
                    active = true;
                    
                    break;
                }
            }
        }

        }
    }
}