using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Animator : MonoBehaviour
{
    // Animates the robot's idle and walking animations
    // Drag the appropriate robot_color animation controller from the :/animation/enemies/robot/color folder 
    // into the object's animator component for the different robots

    // Animation state variables
    Rigidbody2D rb;
    Animator anim;
    const int idle = 0;
    const int walking = 1;

    // Initialize values
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // If the robot isnt moving, change state to idle
        if (rb.velocity.x == 0){
            anim.SetInteger("MoveState",idle);
        }
        // Else, change it to walking
        else{
            anim.SetInteger("MoveState",walking);
        }
    }
}
