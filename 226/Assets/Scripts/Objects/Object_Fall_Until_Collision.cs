using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Fall_Until_Collision : MonoBehaviour
{
    // Causes the object to teleport back to its starting position when it hits another collider
    // Requires the object to have a rigidbody2d
    // Fall speed is handled by mass and gravity in the rigidbody2d component
    Vector2 startingPosition;

    void Start(){
        startingPosition = transform.position;
    }

    // Return to start upon collision
    void OnCollisionEnter2D(Collision2D collision){
        transform.position = startingPosition;
    }

}
