using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player_Movement_Controller : MonoBehaviour
{

    // Movement variables
    Rigidbody2D rb;

    public float runForce = 80;
    public static float maxHorizontalVelocity = 30f;

    public float jumpForce = 40;
    public static float maxVerticalVelocity = 90f;

    public static bool isGrounded = true;

    // Sound variables
    AudioSource sfx;
    // The run sound just isnt sounding great so its all commented out for now
    //public AudioClip runSound;
    public AudioClip jumpSound;

    /* Checks for movement button presses and applies force accordingly */
    void doHorizontalMovement(){
        /* * * RUNNING * * */
        // Apply appropriate directional runForce whenever the arrow keys are pressed.
        if (Input.GetKey(KeyCode.LeftArrow)){
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
        else if (Input.GetKey(KeyCode.RightArrow)){
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

    /* Checks for ground by changing isGrounded to true whenever the terrain layer is collided with */
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Hazards"){
            isGrounded = true;
        }
    }

    /* Checks for jump button presses and applies force accordingly */
    void doVerticalMovement(){
        /* * * JUMPING * * */
        // If the player is grounded, add an upwards jumpForce when they press Up
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,0f); // Reset vertical velocity before jump
            rb.AddForce(transform.up * jumpForce,ForceMode2D.Impulse);
            isGrounded = false;
            // Play sound effect
            sfx.clip = jumpSound;
            sfx.loop = false;
            sfx.Play();
        }
        // When the player lets go of up, they lose upwards velocity faster (Allows for short hops)
        else if (!Input.GetKey(KeyCode.UpArrow) && !isGrounded && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.5f);
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
            // Destroy the game master before loading the space scene
            Destroy(GameObject.Find("GameMaster"));
            Time.timeScale = 1f;
            SceneManager.LoadScene("Space");
        }

        // Press R to reset the level
        if (Input.GetKey(KeyCode.R)){
            // Unpause game, reload scene
            Time.timeScale = 1;
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

