﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Health_and_Damage_Controller : MonoBehaviour
{

    // Initialize all health and death related variables
    public static int maxHealthPoints = 30;
    public static int currentHealthPoints;
    public float invulnerabilityPeriod;
    public Vector2 respawnLocation = new Vector2(1f,2f);

    public static bool isAlive = true;

    // Keeping track of damage for animation purposes
    float timeAtLastDamage = 0f;
    public static bool tookDamageRecently = false;

    void Start(){
        currentHealthPoints = maxHealthPoints/2;
    }

    /* Function to handle player death, should occur when health points hit 0
        Play relevant animations, screen freezes, whatever else is needed
        Resets health points and returns the player to their respawn location */
    void death(){
        // insert death animation trigger here
        currentHealthPoints = 0;
        isAlive = false;

        // Pause game until player presses the restart button
        Time.timeScale = 0;
        
    }

    /* Called whenever the player is hurt 
        dmg is the amount of health points to be lost from this interaction 
        Update tookDamageRecently to let other scripts know to handle damage */
    void takeDamage(int dmg){

        // Only able to take damage once per invulnerabilityPeriod
        if (!tookDamageRecently){
            // Change tookDamageRecently to true, set timeAtLastDamage so Update() knows when to change it back
            // This lets other scripts know to handle damage
            tookDamageRecently = true;
            timeAtLastDamage = Time.time;

            // Subtract dmg from current health, call death() is the player dies
            currentHealthPoints -= dmg;
            if (currentHealthPoints <= 0){
                death();
            }
        }

    }

    /* Whenever the player is in contact with an object with the hazards tag, they take damage */
    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Hazards"){
            takeDamage(10);
        }
    }

    // Check for damage every update
    void Update()
    {
        // press q to die
        if (Input.GetKey(KeyCode.Q)){
            takeDamage(10);
        }

        // If the time since the player last took damage is high enough, reset tookDamageRecently
        if (Time.time - timeAtLastDamage > invulnerabilityPeriod){
            tookDamageRecently = false;
        }

        // Press R to restart the level
        if (Input.GetKey(KeyCode.R)){
            // Unpause game, reset current scene
            Time.timeScale = 1;
            isAlive = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
