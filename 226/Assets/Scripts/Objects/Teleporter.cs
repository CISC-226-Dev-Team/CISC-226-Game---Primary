using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public Transform destination;

    // Teleport the player to the given location when they touch this trigger
    void OnTriggerEnter2D(Collider2D collision){
        player.transform.position = destination.position;
    }
}
