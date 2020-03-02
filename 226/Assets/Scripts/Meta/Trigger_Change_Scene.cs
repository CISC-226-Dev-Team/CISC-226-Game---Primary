using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_Change_Scene : MonoBehaviour
{

    public string sceneName;

    // If the player enters the trigger hitbox, load the given scene
    // Requires the triggering object to have a trigger hitbox
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            // Destroy the GameMaster before leaving!
            Destroy(GameObject.Find("GameMaster"));
            // Find the SceneManager and change its target scene before calling the transition
            Scene_Transition SC = GameObject.Find("SceneController").GetComponent<Scene_Transition>();
            SC.escScene = sceneName;
            SC.transition();
        }
    }
}
