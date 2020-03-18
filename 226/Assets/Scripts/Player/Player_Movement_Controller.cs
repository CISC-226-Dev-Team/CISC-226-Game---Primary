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
    int holdingMove = 0;

    public float jumpVelocity;
    public static float maxVerticalVelocity = 90f;
    public float jumpBufferLength;
    float jumpBuffer = 0f;
    bool holdingJump = false;

    public static bool isGrounded = true;

    // Sound variables
    AudioSource sfx;
    public AudioClip jumpSound;

    /* Checks for ground by changing isGrounded to true whenever terrain is collided with */
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Hazards" || collision.gameObject.tag == "One_Way_Platforms"){
            isGrounded = true;
        }
    }

    /* Applies vertical (jump) physics */
    void doVerticalMovement(){
        /* * * JUMPING * * */
        // If the player is grounded, add an upwards velocity when they jump
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
        else if (!holdingJump && !isGrounded && rb.velocity.y > 0){
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
    // Keyboard inputs are collected in update, and executed in fixed update
    void Update()
    {

        // W and Space jump
        // Remember their press for a small time, so that the player can press jump slightly before they touch the ground
        jumpBuffer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)){
            jumpBuffer = jumpBufferLength;
        }

        // Holding the jump button allows you to jump higher
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)){
            holdingJump = true;
        }
        else{
            holdingJump = false;
        }

        // A and D to move left and right
        if (Input.GetKey(KeyCode.A)){
            holdingMove = -1;
        }
        else if (Input.GetKey(KeyCode.D)){
            holdingMove = 1;
        }
        else{
            holdingMove = 0;
        }

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
        rb.AddForce(transform.right * runForce * holdingMove); // Apply run force
        doVerticalMovement(); // Apply jump physics
        limitVelocity(); // Afterwars, limit maximum velocity
    }
}

