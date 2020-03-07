using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    // This will cause a platform to move back and forth a set distance at a set speed
    public float horizontalDistance;
    public float horizontalSpeed;
    public float verticalDistance;
    public float verticalSpeed;

    Vector2 originalLocation;
    Vector2 standardDirection = new Vector2(1,1);

    // Keep track of original location for reference
    void Start(){
        originalLocation = transform.position;
    }

    // Move the platform until the given distances have been reached, then return
    void Update(){
        // Apply movement forces, relative to the world coordinates (not relative coordinates)
        transform.Translate(standardDirection * new Vector2(Time.deltaTime * horizontalSpeed,Time.deltaTime * verticalSpeed),Space.World);
        // Check position, both horizontally and vertically
        // If position has exceeded the given distance, or has returned to the original position, swap the direction of movement
        if (transform.position.x > originalLocation.x+horizontalDistance){
            horizontalSpeed *= -1;
        }
        else if (transform.position.x < originalLocation.x){
            horizontalSpeed *= -1;
        }
        // Do the same for vertical positions
        if (transform.position.y > originalLocation.y+verticalDistance){
            verticalSpeed *= -1;
        }
        else if (transform.position.y < originalLocation.y){
            verticalSpeed *= -1;
        }
    }

    // While the player is touching the platform, update their position with the platform
    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.transform.Translate(Time.deltaTime * horizontalSpeed,Time.deltaTime * verticalSpeed,0);
        }
    }
}
