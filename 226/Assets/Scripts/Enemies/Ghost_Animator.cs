using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Animator : MonoBehaviour
{
    // Animates the ghost's idle and walking animations

    // Animation state variables
    Rigidbody2D rb;
    Animator anim;
    const int invisible = 0;
    const int idle = 1;


    // Initialize values
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Upon entering trigger range, the ghost appears
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            anim.SetInteger("MoveState",idle);
        }
    }

    // Upon exiting trigger range, the ghost vanishes
    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            anim.SetInteger("MoveState",invisible);
        }
    }
    
}
