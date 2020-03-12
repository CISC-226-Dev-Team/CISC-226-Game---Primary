using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Fall_Until_Collision : MonoBehaviour
{
    // Causes the object to teleport back to its starting position when it hits another collider
    // Requires the object to have a rigidbody2d
    // Fall speed is handled by mass and gravity in the rigidbody2d component
    Vector2 startingPosition;
    Rigidbody2D rb;

    // For the "deathAnim" one-shot prefab that gets created upon collision
    public GameObject deathAnim;
    public Vector3 deathAnimOffset;

    void Start(){
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Upon colliding with terrain, return to starting position
    void OnCollisionEnter2D(Collision2D collision){
        // Play the "death" anim
        var death = (GameObject)Instantiate(deathAnim,transform.position+deathAnimOffset,transform.rotation);
        // Return to start
        transform.position = startingPosition;
        // Reset velocity
        rb.velocity = new Vector2(0,0);
        
    }

}
