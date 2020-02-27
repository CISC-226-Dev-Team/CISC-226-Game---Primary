using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Animation_Controller : MonoBehaviour
{

    // Player related values
    public Rigidbody2D rb;
    float xVel;
    float yVel;

    public SpriteRenderer spr;
    public Color normalColor;
    public Color damageColor;

    // Animation state variables
    Animator anim;
    const int idle = 0;
    const int runLeft = 1;
    const int runRight = 2;
    const int jumpLeft = 3;
    const int jumpRight = 4;

    // Initialize values
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    /* Check player movement values and update the animation state accordingly */
    void movementAnimations(){
        // Get the player's facing direction
        xVel = rb.velocity.x;
        yVel = rb.velocity.y;

        // Update grounded states (Idle and directional running)
        if (Player_Movement_Controller.isGrounded){
            if (xVel == 0){
                anim.SetInteger("MoveState",idle);
            }
            else if (xVel < 0){
                anim.SetInteger("MoveState",runLeft);
            }
            else if (xVel > 0){
                anim.SetInteger("MoveState",runRight);
            }
            // Scale RunSpeed (which multiplies the speed of the running animation) to velocity
            anim.SetFloat("RunSpeed",(Math.Abs(xVel/Player_Movement_Controller.maxHorizontalVelocity))*3.5f);
        }
        // Update jumping states
        else{
            if (xVel < 0){
                anim.SetInteger("MoveState",jumpLeft);
            }
            else if (xVel >= 0){
                anim.SetInteger("MoveState",jumpRight);
            }
        }
    }

    /* Play the damage animation so long as damage was taken recently */
    void damageAnimations(){
        
        if (Player_Health_and_Damage_Controller.tookDamageRecently){
            spr.color = damageColor;
            anim.SetBool("DmgAnimation",true);
        }
        else{
            spr.color = normalColor;
            anim.SetBool("DmgAnimation",false);
        }

    }

    // Update animation states every frame
    void Update()
    {
        movementAnimations();
        damageAnimations();
    }

}
