using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class BoardManager : MonoBehaviour {
    public Transform tileContainer;
    public GameObject[] tilePrefabs;

    Dictionary<String, int> tileType = new Dictionary<String, int>
    {
        { "pod", 0 },
        { "block", 1}
    };

    void OnEnable () {
        GameEvents.listen("LOAD_BOARD", load);
        GameEvents.listen("REPLAY", load);
        
        
    }
    void OnDisable() {
        GameEvents.stopListening("LOAD_BOARD", load);
        GameEvents.stopListening("REPLAY", load);
    }

    void load() {
        if (tileContainer.childCount > 0) {
            for(int i = 0; i < tileContainer.childCount; i++)
            {
                Destroy(tileContainer.GetChild(i).gameObject);
            }
 
        }
        
        Tile[] tiles = State.lvlInfo.tiles;
        Tile tile;
        for (int i = 0; i < tiles.Length; i++)
        {
            tile = tiles[i];
            GameObject instance = Instantiate(
                tilePrefabs[tileType[tile.type]],
                new Vector3( tile.x, tile.y, 0f),
                Quaternion.identity
                );

            instance.transform.SetParent(tileContainer);
        }
        alignBoard();
    }

    void alignBoard() {
        Vector3 pos = tileContainer.position;
        float maxX = 0f;
        float maxY = 0f;
        float minX = 0f;
        float minY = 0f;

        for(int i = 0; i < tileContainer.childCount; i++)
        {
            Transform elem = tileContainer.GetChild(i);
            Vector3 elemMax = getMaxBounds(elem.gameObject);
            Vector3 elemMin = getMaxBounds(elem.gameObject);
            maxX = Mathf.Max(elemMax.x, maxX);
            maxY = Mathf.Max(elemMax.y, maxY);
            minX = Mathf.Min(elemMin.x, minX);
            minY = Mathf.Min(elemMin.y, minY);
        }
 

        float xOffset = (GlobalVars.Instance.MaxCameraBounds.x - (maxX - minX))/2;
        float yOffset = (GlobalVars.Instance.MaxCameraBounds.y - (maxY - minY))/2;

        tileContainer.position = new Vector3(pos.x-xOffset, pos.y-yOffset, pos.z);
    }

    Vector3 getMaxBounds(GameObject target) {
        Vector3 result = Vector3.zero;
        if (target.GetComponent<BoxCollider2D>()) {
            result = target.GetComponent<BoxCollider2D>().bounds.max;
        } else if (target.GetComponent<CircleCollider2D>()) {
            result = target.GetComponent<CircleCollider2D>().bounds.max;
        }

        return result;
    }

    Vector3 getMinBounds(GameObject target) {
        Vector3 result = Vector3.zero;
        if (target.GetComponent<BoxCollider2D>()) {
            result = target.GetComponent<BoxCollider2D>().bounds.min;
        } else if (target.GetComponent<CircleCollider2D>()) {
            result = target.GetComponent<CircleCollider2D>().bounds.min;
        }

        return result;
    }

    void Start() {
        load();
    }
}