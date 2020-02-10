using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Movement_Controller : MonoBehaviour
{

    // Movement variables
    Rigidbody2D rb;
    public float thrust;
    public float turnSpeed;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    /* Called at FixedUpdate, handles the spaceship movement */ 
    void shipMovementHandler(){
        // Up and down keys apply forwards and backwards forces
        if (Input.GetKey(KeyCode.UpArrow)){
            rb.AddRelativeForce(new Vector2(0,thrust));
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            rb.AddRelativeForce(new Vector2(0,thrust*-1));
        }
        // Left and right keys rotate the ship
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.forward * turnSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.forward * turnSpeed * -1);
        }
    }

    void Update(){
        // ESC quits the game 
        if (Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }

    // Handle spaceship movement at FixedUpdate
    private void FixedUpdate()
    {
        shipMovementHandler();
    }
}
