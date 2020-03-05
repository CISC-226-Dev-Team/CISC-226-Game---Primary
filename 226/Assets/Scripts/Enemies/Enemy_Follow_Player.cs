using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow_Player : MonoBehaviour
{
    // Follows the player's position when they enter trigger range
    // Trigger range is determined by a trigger collider on the enemy object
    // The "hitbox" child object on the enemy object determines what part actually harms the player
    // The hitbox should have a trigger collider that is slightly larger than the enemy's actual collider
    // Only hitbox needs to have the Hazards tag, enemy itself does not need a tag

    // Movement values
    public float moveSpeed;
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

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Follow the player
    void OnTriggerStay2D(Collider2D collider){
        // When the player is in trigger range, move towards their position
        if (collider.CompareTag("Player")){
            playerPosition = collider.gameObject.transform.position;
            // If the player is to the right, move right
            if (playerPosition.x > transform.position.x){
                rb.AddForce(transform.right * moveSpeed);
                // Flip the sprite to always be facing the player
                spr.flipX = false;
            }
            // If the player is to the left, move left
            else if (playerPosition.x < transform.position.x){
                rb.AddForce(transform.right * moveSpeed * -1);
                // Flip the sprite to always be facing the player
                spr.flipX = true;
            }
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
        }
    }

    void Update(){

        // Dies (Destroys self) when health reaches zero
        if (healthPoints <= 0){
            Destroy(gameObject);
        }

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
