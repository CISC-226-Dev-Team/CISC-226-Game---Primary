using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // When touching the checkpoint, update player data to the Game_Master
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
            gm.respawnLocation = transform.position;
            gm.respawnHealthPoints = Player_Health_and_Damage_Controller.currentHealthPoints;
            gm.respawnScore = Player_Item_Interactions_Controller.score;
        }
    }
}
