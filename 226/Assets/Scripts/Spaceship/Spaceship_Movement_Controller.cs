﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship_Movement_Controller : MonoBehaviour
{

    // Movement variables
    Rigidbody2D rb;
    public float thrust;
    public float turnSpeed;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // At awake, place the ship at the last checkpoint position
    void Awake(){
        Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        transform.position = gm.shipLocation;
    }

    /* Called at FixedUpdate, handles the spaceship movement */ 
    void shipMovementHandler(){
        // Up and down keys apply forwards and backwards forces
        if (Input.GetKey(KeyCode.W)){
            rb.AddRelativeForce(new Vector2(0,thrust));
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddRelativeForce(new Vector2(0,thrust*-1));
        }
        // Left and right keys rotate the ship
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.forward * turnSpeed * -1);
        }
    }

    void Update(){
        // ESC returns to main menu
        if (Input.GetKey(KeyCode.Escape)){
            Scene_Transition SC = GameObject.Find("SceneController").GetComponent<Scene_Transition>();
            SC.transition();
        }
    }

    // Handle spaceship movement at FixedUpdate
    private void FixedUpdate()
    {
        shipMovementHandler();
    }
}
