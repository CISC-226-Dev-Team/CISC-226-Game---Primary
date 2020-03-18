using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Way_Platforms : MonoBehaviour
{

    Collider2D playerCollider;
    Collider2D self;

    // Initialize colliders for both player and self
    void Start(){
        playerCollider = GameObject.Find("Player").GetComponent<Player_Movement_Controller>().GetComponent<Collider2D>();
        self = GetComponent<Collider2D>();
    }

    // When holding down, the player can fall through the one way platforms
    void Update()
    {
        // When down is being held, set IgnoreCollision between the player and the platforms to true
        if (Input.GetKeyDown(KeyCode.S)){
            Physics2D.IgnoreCollision(playerCollider, self, true);
        }
        // Once released, it's set back to false
        if (Input.GetKeyUp(KeyCode.S)){
            Physics2D.IgnoreCollision(playerCollider, self, false);
        }
    }
}
