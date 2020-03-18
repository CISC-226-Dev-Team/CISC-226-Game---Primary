using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;

    Game_Master gm; 

    void Start(){
        gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
    }

    // Teleport the player to the given location when they touch this trigger
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.transform.position = destination.position;

            // De-activate phase one
            gm.phase_one.SetActive(false);
            // Activate phase-two
            gm.phase_two.SetActive(true);
        }
    }
}
