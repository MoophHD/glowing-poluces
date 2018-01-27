using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class BoardManager : MonoBehaviour {
    private Vector3 alignVector = new Vector3(-100f, -100f, -100f);
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
        const float SIZE_X = 5;
        const float SIZE_Y = 5;

        tileContainer.position = Vector3.zero;
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

        tileContainer.position = new Vector3(-SIZE_X/2, SIZE_Y/2, 0f);
    }

    void alignBoard() {
        if (alignVector != new Vector3(-100f, -100f, -100f)) {
            tileContainer.position = alignVector;
            return;
        }

        float maxX = 0f;
        float maxY = 0f;
        float minX = 0f;
        float minY = 0f;

        for(int i = 0; i < tileContainer.childCount; i++)
        {
            Transform elem = tileContainer.GetChild(i);
            Vector3 elemMax = getMaxBounds(elem.gameObject);
            Vector3 elemMin = getMinBounds(elem.gameObject);
            maxX = Mathf.Max(elemMax.x, maxX);
            maxY = Mathf.Max(elemMax.y, maxY);
            minX = Mathf.Min(elemMin.x, minX);
            minY = Mathf.Min(elemMin.y, minY);
        }
        
        float xOffset = (-(maxX - minX))/2;
        float yOffset = (-(maxY - minY))/2;
    
        alignVector = new Vector3(xOffset, yOffset, 0f);
        tileContainer.position = alignVector;
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