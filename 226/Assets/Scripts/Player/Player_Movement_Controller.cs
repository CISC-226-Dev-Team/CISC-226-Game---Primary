using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player_Movement_Controller : MonoBehaviour
{

    // Movement variables
    Rigidbody2D rb;

    public float runForce;
    public static float maxHorizontalVelocity = 30f;

    public float jumpVelocity;
    public static float maxVerticalVelocity = 90f;
    public float jumpBufferLength;
    float jumpBuffer = 0f;

    public static bool isGrounded = true;

    // Sound variables
    AudioSource sfx;
    // The run sound just isnt sounding great so it's all commented out for now
    //public AudioClip runSound;
    public AudioClip jumpSound;

    /* Checks for movement button presses and applies force accordingly */
    void doHorizontalMovement(){
        /* * * RUNNING * * */
        // Apply appropriate directional runForce whenever the arrow keys are pressed.
        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(transform.right * runForce * -1);
            // Play running sound if grounded
            /*
            if (isGrounded){
                if (!sfx.loop){
                    sfx.clip = runSound;
                    sfx.Play();
                }
                sfx.loop = true;
            }
            */
        }
        else if (Input.GetKey(KeyCode.D)){
            rb.AddForce(transform.right * runForce);
            // Play running sound if grounded
            /*
            if (isGrounded){
                if (!sfx.loop){
                    sfx.clip = runSound;
                    sfx.Play();
                }
                sfx.loop = true;
            }
            */
        }
        /*
        else{
            // Disable looping run sound if not running
            sfx.loop = false;
        }
        */
    }

    /* Checks for ground by changing isGrounded to true whenever terrain is collided with */
    void OnCollisionEnter2D(Collision2D collision){
        // Terrain and hazards ground the player at any time
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Hazards"){
            isGrounded = true;
        }
        // One way platforms only ground when falling
        else if (collision.gameObject.tag == "One_Way_Platforms"){
            if (rb.velocity.y <= 0f){
                isGrounded = true;
            }
        }
    }

    /* Checks for jump button presses and applies force accordingly */
    void doVerticalMovement(){
        /* * * JUMPING * * */
        // If the player is grounded, add an upwards velocity when they press Up
        // Remember their press for a small time, so that the player can press jump slightly before they touch the ground
        jumpBuffer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)){
            jumpBuffer = jumpBufferLength;
        }
        if ((jumpBuffer > 0) && isGrounded){
            // Set the vertical velocity to jumpVelocity
            rb.velocity = new Vector2(rb.velocity.x,jumpVelocity); 
            isGrounded = false;
            jumpBuffer = 0;
            // Play sound effect
            sfx.clip = jumpSound;
            sfx.loop = false;
            sfx.Play();
        }
        // When the player lets go of up, they lose upwards velocity faster (Allows for short hops)
        else if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.W) && !isGrounded && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.7f);
        }

    }

    /* Called at FixedUpdate, after control inputs
       Limits the player's velocity in all directions to stop them from going too fast */
    void limitVelocity(){
        // Cap both horizontal and vertical velocities
        float playerVelocityX = rb.velocity.x;
        float playerVelocityY = rb.velocity.y;

        if (playerVelocityX >= maxHorizontalVelocity){
            playerVelocityX = maxHorizontalVelocity;
        }
        else if (playerVelocityX <= maxHorizontalVelocity*-1){
            playerVelocityX = maxHorizontalVelocity*-1;
        }

        if (playerVelocityY >= maxVerticalVelocity){
            playerVelocityY = maxVerticalVelocity;
        }
        // No cap on downwards velocity?
        //else if (playerVelocityY <= maxVerticalVelocity*-1){
        //    playerVelocityY = maxVerticalVelocity*-1;
        //}

        // Update velocity accordingly
        rb.velocity = new Vector2(playerVelocityX,playerVelocityY);
    }

    /* Initialize rigidbody variable at game start */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();
    }

    // Reset position to last checkpoint position
    void Awake(){
        Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        transform.position = gm.respawnLocation;
    }

    // Update is called once per frame
    void Update()
    {
        // ESC key exits the game into level select
        if (Input.GetKey(KeyCode.Escape)){
            // Reset the timeScale
            Time.timeScale = 1f;
            // Get the scene transition object and sets its scene to Space
            Scene_Transition SC = GameObject.Find("SceneController").GetComponent<Scene_Transition>();
            SC.escScene = "Space";
            SC.transition();
        }

        // Press R to reset the level
        if (Input.GetKey(KeyCode.R)){
            // Unpause game, reload scene
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /* FixedUpdate: Update all physics/movement functions */
    private void FixedUpdate(){
        doHorizontalMovement();
        doVerticalMovement();
        limitVelocity();
    }
}

