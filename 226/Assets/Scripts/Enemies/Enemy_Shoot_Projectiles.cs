using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot_Projectiles : MonoBehaviour
{
    // This will cause an enemy to shoot hazardous bullets at the player

    // Shooting variables
    public GameObject bullet;
    public float shootCooldown;
    float nextFireTime;
    public float distanceFromCentre; // Determines where the bullet is spawned, as the bullet spawning inside the enemy causes problems

    // Only shoots while the player is within range
    // Requires a trigger collider to act as the detection radius
    bool isActive = false;

    // Sprite renderer is used for telling direction
    SpriteRenderer spr;

    // For playing audio:
    AudioSource sfx;
    public AudioClip shootSound;

    void Start(){
        spr = GetComponent<SpriteRenderer>();
        sfx = GetComponent<AudioSource>();
    }

    // Is only active when the player enters detection range
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            isActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            isActive = false;
        }
    }

    void Update(){
        if (Time.time > nextFireTime && isActive){
            // Reset fire time based on cooldown
            nextFireTime = Time.time + shootCooldown;

            // Fire the projectile:
            // Get facing direction from sprite renderer
            // FlipX false means right
            if (!spr.flipX){
                var projectile = (GameObject)Instantiate(bullet,transform.position+new Vector3(distanceFromCentre,0f,0f),transform.rotation);
                projectile.GetComponent<Projectile_Move_Forward>().setDirection(1);
            }
            // FlipX true means left
            else{
                var projectile = (GameObject)Instantiate(bullet,transform.position+new Vector3(distanceFromCentre*-1,0f,0f),transform.rotation);
                projectile.GetComponent<Projectile_Move_Forward>().setDirection(-1);
            }

            // Play sound clip
            sfx.clip = shootSound;
            sfx.Play();
        }
    }
}
