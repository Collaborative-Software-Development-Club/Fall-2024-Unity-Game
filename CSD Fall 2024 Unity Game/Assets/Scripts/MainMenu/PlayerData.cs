using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    /**
     * Scene 0: Main scene
     * Scene 1: Maze
     * Scene 2: Farm
     * Scene 3: Cave
     */
    public int scene;

    public PlayerData (int scene) {
        this.scene = scene; 
    }
}
