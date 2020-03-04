using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item_Interactions_Controller : MonoBehaviour
{

    Game_Master gm;

    // Scoring variables
    public static int score;
    public static int numCoins;

    // Shooting variables
    public GameObject bullet;
    public float shootCooldown;
    float nextFireTime;

    // Phase tracker and timer variables
    bool phaseTwo;
    public float timerInterval;
    float nextInterval;

    // Sound variables
    AudioSource sfx;
    public AudioClip deathSound;
    public AudioClip coinSound;
    public AudioClip medkitSound;
    public AudioClip shootSound;

    // Initialize values
    void Start(){
        sfx = GetComponent<AudioSource>();
        // Count number of coins on start
        numCoins = GameObject.Find("Coins").transform.childCount;
    }

    // Reset score to last checkpoint
    void Awake(){
        gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        score = gm.respawnScore;
        phaseTwo = gm.phaseTwo;
    }

    // Whenever an object with a trigger hitbox is touched, check what it is and resolve accordingly by checking tags
    void OnTriggerEnter2D(Collider2D collision){

        // Coins increase score by 1, then disappear
        if (collision.CompareTag("Item_Coin")){
            Destroy(collision.gameObject);
            score += 1;
            // Play coin pickup sound effect
            sfx.clip = coinSound;
            sfx.loop = false;
            sfx.Play();
        }

        // Medkits restore 5 health, up to the maximum, then disappear
        else if (collision.CompareTag("Item_Medkit")){
            if (Player_Health_and_Damage_Controller.currentHealthPoints < Player_Health_and_Damage_Controller.maxHealthPoints){
                Destroy(collision.gameObject);
                Player_Health_and_Damage_Controller.currentHealthPoints += 5;
                // Play medkit pickup sound effect
                sfx.clip = medkitSound;
                sfx.loop = false;
                sfx.Play();
            }
        }

    }

    // Allow the player to shoot bullets at the cost of coins
    void Update(){

        // Whenever shoot button is pressed, check that:
        // The player has coins left
        // The player has not fired recently
        if ( (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.P)) && Time.time > nextFireTime){

            // Reset fire time based on cooldown
            nextFireTime = Time.time + shootCooldown;

            // Left shoot button fires to the left (-1)
            if (Input.GetKey(KeyCode.O)){
                var projectile = (GameObject)Instantiate(bullet,transform.position+new Vector3(-1.5f,0f,0f),transform.rotation);
                projectile.GetComponent<Projectile_Move_Forward>().setDirection(-1);
            }
            // Right shoot button fires to the right (+1)
            else if (Input.GetKey(KeyCode.P)){
                var projectile = (GameObject)Instantiate(bullet,transform.position+new Vector3(1.5f,0f,0f),transform.rotation);
                projectile.GetComponent<Projectile_Move_Forward>().setDirection(1);
                
            }
            
            // Play shoot sound
            sfx.clip = shootSound;
            sfx.loop = false;
            sfx.Play();

            // *Remove 1 score* Shooting no longer costs coins so this isnt needed
            // Checking if score > 0 has also been remove from the containing if statement
            //score -= 1;
            
        }

        // If the player is in phase two, the timer (based on coins collected) begin ticking down
        if (phaseTwo){
           // Every frame, check if the next timer interval has been reached
           if (Time.time >= nextInterval){
               // If it has, remove 1 score and set the next interval
               score -= 1;
               nextInterval = Time.time + timerInterval; 
           }

           // If the player has 0 score, the timer is out and they die
           if (score <= 0){
               // Make sure to only die once
               if (Player_Health_and_Damage_Controller.isAlive){
                   sfx.clip = deathSound;
                   sfx.loop = false;
                   sfx.Play();
                   Player_Health_and_Damage_Controller.death();
               }
           }

        }
        else{
            // Check for phase updates
            phaseTwo = gm.phaseTwo;
        }
        

    }

}
