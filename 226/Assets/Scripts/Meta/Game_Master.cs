using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Master : MonoBehaviour
{
    // The Game_Master handles respawning and level resetting
    private static Game_Master instance;
    // All relevant values are tracked here, preserved between level reloads
    public Vector2 respawnLocation;
    public int respawnHealthPoints;
    public int respawnScore;
    // Any additional values that need to stay constant through scene reloads can be stored here

    void Awake(){
        // Create an instance of GameMaster if there isnt one already
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }
        // if there is, destroy it to prevent multiple game masters from existing
        else{
            Destroy(gameObject);
        }
    }
}
