using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Animator : MonoBehaviour
{
    // Animates the skeleton rising out of the ground upon being triggered
    // Once he has risen, he remains in his standing state

    Rigidbody2D rb;
    Animator anim;
    const int hidden = 0;
    const int idle = 1;
    const int walk = 2;

    // Initialize values
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Rise upon trigger
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            anim.SetInteger("MoveState",idle);
            anim.SetBool("Revealed",true);
        }
    }

    // Alternate walk and idle depending on movement
    void Update(){
        // If the skeleton isnt moving, change state to idle
        if (rb.velocity.x == 0){
            anim.SetInteger("MoveState",idle);
        }
        // Else, change it to walk
        else{
            anim.SetInteger("MoveState",walk);
        }
    }
}
