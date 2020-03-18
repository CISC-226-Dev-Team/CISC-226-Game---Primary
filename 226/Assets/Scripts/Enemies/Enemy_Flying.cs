using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Flying : MonoBehaviour
{
    // Follows the player's position when they enter trigger range
    // Trigger range is determined by a trigger collider on the enemy object
    // The "hitbox" child object on the enemy object determines what part actually harms the player
    // The hitbox should have a trigger collider that is slightly larger than the enemy's actual collider
    // Only hitbox needs to have the Hazards tag, enemy itself does not need a tag

    // Variation of Enemy_Follow_Player that allows the enemy to move itself vertically as well
    // Gravity scale should be 0 or close to it to ensure the enemy can actually fly

    // Movement values
    public float moveForce;
    int directionX;
    int directionY;
    Vector2 playerPosition;
    Rigidbody2D rb;

    // Behavior values
    public float healthPoints;

    // Animation values
    SpriteRenderer spr;
    public Color normalColor;
    public Color damageColor;
    float timeAtLastDamage = 0f;
    bool tookDamageRecently = false;
    public GameObject deathAnim;
    public Vector3 deathAnimOffset;

    // Audio values
    AudioSource sfx;
    public AudioClip oofSound;

    // Player object
    Transform player;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        sfx = GetComponent<AudioSource>();
        directionX = 0;
        directionY = 0;
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Follow the player
    void OnTriggerStay2D(Collider2D collider){
        // When the player is in trigger range, move towards their position
        if (collider.CompareTag("Player")){
            playerPosition = collider.gameObject.transform.position;
            // If the player is to the right, move right
            if (player.position.x > transform.position.x){
                directionX = 1;
                // Flip the sprite to always be facing the player
                spr.flipX = false;
            }
            // If the player is to the left, move left
            else {
                directionX = -1;
                // Flip the sprite to always be facing the player
                spr.flipX = true;
            }
            // If the player is up, move up
            if (player.position.y > transform.position.y){
                directionY = 1;
            }
            // If the player is down, move down
            else {
                directionY = -1;
            }
        }
    }

    // Stop moving when the player leaves trigger range
    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            directionX = 0;
            directionY = 0;
        }
    }

    // Take damage when shot
    void OnCollisionEnter2D(Collision2D collision){
        // When hit with an object with tag "Player_Bullet", this enemy has been shot
        // Put any behaviours for being shot in here
        // By default, shooting an enemy causes it to take damage. When it's health reaches 0, it dies
        if (collision.gameObject.tag == "Player_Bullet"){
            healthPoints -= 1;
            // Change color when shot
            timeAtLastDamage = Time.time;
            tookDamageRecently = true;

            // Dies (Destroys self) if health reaches zero
            if (healthPoints <= 0){
                // Create a death animation object
                // This object will include the death sound
                var death = (GameObject)Instantiate(deathAnim,transform.position+deathAnimOffset,transform.rotation);
                // Destroy self
                Destroy(gameObject);
            }
            else{
                // If it survives, play oof sound
                sfx.clip = oofSound;
                sfx.Play();
            }
        }
    }

    // Do physics calculations at fixed update
    void FixedUpdate(){
        if (directionX != 0){
            rb.AddForce(transform.right * moveForce * directionX);
        }
        if (directionY != 0){
            rb.AddForce(transform.up * moveForce * directionY);
        }
    }

    void Update(){

        // Animate the color change when the enemy is shot
        if (Time.time - timeAtLastDamage > 0.2){
            tookDamageRecently = false;
        }
        if (tookDamageRecently){
            spr.color = damageColor;
        }
        else{
            spr.color = normalColor;
        }
    }
}
