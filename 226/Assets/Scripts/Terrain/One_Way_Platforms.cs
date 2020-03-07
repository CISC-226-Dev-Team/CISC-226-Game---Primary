using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Way_Platforms : MonoBehaviour
{

    public Transform player;

    // When holding down, the player can fall through the one way platforms
    void Update()
    {
        // When down is being held, set IgnoreCollision between the player and the platforms to true
        if (Input.GetKey(KeyCode.S)){
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        // Once released, it's set back to false
        else{
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }
}
