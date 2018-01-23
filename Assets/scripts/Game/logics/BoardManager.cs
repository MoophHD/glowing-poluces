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
        
    }
    void OnDisable() {
        GameEvents.stopListening("LOAD_BOARD", load);
    }

    void load() {
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
    }

    //temp
    void Start() {
        // load();
        
    }
}