using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_Change_Scene : MonoBehaviour
{

    public string sceneName;
    // This will be used for planet scanning in the space screen
    // sceneInfo is the text to be displayed on the planet scanner when the player gets close to a planet
    public string sceneInfo; 

    // If the player enters the trigger hitbox, load the given scene
    // Requires the triggering object to have a trigger hitbox
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            // Destroy the GameMaster before leaving!
            Destroy(GameObject.Find("GameMaster"));
            SceneManager.LoadScene(sceneName);
        }
    }
}
