using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class BoardManager : MonoBehaviour {

    private enum TileType { block };

    void OnEnable () {
        GameEvents.listen("LOAD_BOARD", load);
        
    }
    void OnDisable  () {
        GameEvents.stopListening("LOAD_BOARD", load);
    }

    void load() {
        Tile[] tiles = State.lvlInfo.tiles;
        Tile tile;
        for (int i = 0; i < tiles.Length; i++)
        {
            tile = tiles[i];
            print(tile.x);
        }
    }

    void genBoard() {

    }


    //temp
    void Start() {
        load();
        
    }
}