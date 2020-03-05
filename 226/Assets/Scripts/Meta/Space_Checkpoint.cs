using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Checkpoint : MonoBehaviour
{
    // When touching the checkpoint area, send ship location to the game master
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Spaceship")){
            Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
            gm.shipLocation = collision.gameObject.transform.position;
            // This also resets all game master values
            gm.respawnHealthPoints = 15;
            gm.respawnScore = 0;
            gm.phaseTwo = false;
            gm.checkpointed = false;
        }
    }
}
