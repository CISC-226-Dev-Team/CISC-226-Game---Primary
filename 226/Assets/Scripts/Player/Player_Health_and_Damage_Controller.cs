using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health_and_Damage_Controller : MonoBehaviour
{

    // Initialize all health and death related variables
    public static int maxHealthPoints;
    public static int currentHealthPoints;
    public float invulnerabilityPeriod;
    public static bool isAlive;

    // Keeping track of damage for animation purposes
    float timeAtLastDamage = 0f;
    public static bool tookDamageRecently = false;

    // Sound effect variables
    AudioSource sfx;
    public AudioClip ouchSound;
    public AudioClip deathSound;

    // Initialize values 
    void Start(){
        isAlive = true;
        sfx = GetComponent<AudioSource>();
        // Max health is based on how many medkits there are in the level
        maxHealthPoints = GameObject.Find("Medkits").transform.childCount*5 + 15;
    }

    // Reset health points to last checkpoint
    void Awake(){
        Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        currentHealthPoints = gm.respawnHealthPoints;
    }

    /* Function to handle player death, should occur when health points hit 0
        Play relevant animations, screen freezes, whatever else is needed
        Resets health points and returns the player to their respawn location */
    public static void death(){
        // insert death animation trigger here

        // become dead
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
                currentHealthPoints = 0;
                // Play death sound effect
                sfx.clip = deathSound;
                sfx.loop = false;
                sfx.Play();
                // die
                death();
            }
            else{
                // Play the damage sound effect if the player survives
                sfx.clip = ouchSound;
                sfx.loop = false;
                sfx.Play();
            }
        }

    }

    /* Whenever the player is in contact with an object with the hazards tag, they take damage */
    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Hazards"){
            takeDamage(5);
        }
    }

    /* Whenever the player touches an object with the hazards tag, they take damage */
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Hazards"){
            takeDamage(5);
        }
    }

    /* Whenever the player is within a hazardous trigger space, they take damage */
    void OnTriggerStay2D(Collider2D collider){
        if (collider.CompareTag("Hazards")){
            takeDamage(5);
        }
    }

    // Check for damage every update
    void Update()
    {

        // If the time since the player last took damage is high enough, reset tookDamageRecently
        if (Time.time - timeAtLastDamage > invulnerabilityPeriod){
            tookDamageRecently = false;
        }

    }
}
