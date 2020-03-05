using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_Change_Scene : MonoBehaviour
{

    public string sceneName;
    public Vector2 spawnLocation;

    // If the player enters the trigger hitbox, load the given scene
    // Requires the triggering object to have a trigger hitbox
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Spaceship") || collision.CompareTag("Player")){
            // A level's spawn location must be defined here, in its planet script
            Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
            gm.respawnLocation = spawnLocation;
            // Find the SceneManager and change its target scene before calling the transition
            Scene_Transition SC = GameObject.Find("SceneController").GetComponent<Scene_Transition>();
            SC.escScene = sceneName;
            SC.transition();
        }
    }
}
