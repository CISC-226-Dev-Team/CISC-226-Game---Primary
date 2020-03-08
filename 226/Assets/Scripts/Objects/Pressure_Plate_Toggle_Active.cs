using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate_Toggle_Active : MonoBehaviour
{
    // Pressure plates toggle the active state of the given object whenever something is standing on them

    // The game object to be toggled
    public GameObject target;
    // By default, a pressure plate changes an object from deactive to active when pushed
    // With invertStates on, the plate will change an object from active to deactive instead
    public bool invertStates; 
    bool activeState;

    // Toggling the switch also has sound effects and different sprites
    AudioSource sfx;
    public AudioClip onSound;
    public AudioClip offSound;
    SpriteRenderer spr;
    public Sprite onSprite;
    public Sprite offSprite;

    void Start(){
        activeState = invertStates;
        target.SetActive(activeState);
        sfx = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();

        // Initialize sprite
        if (activeState){
            spr.sprite = onSprite;
        }
        else{
            spr.sprite = offSprite;
        }
    }

    // Change activeState whenever an object is on the plate
    // With invertStates set to true, an object being on the plate sets activeState to false
    // With invertStates set to false, an object being on the plate sets activeState to true
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player") || collider.CompareTag("Hazards")){
            activeState = !invertStates;
            // Change sound and sprite
            sfx.clip = onSound;
            sfx.Play();
            spr.sprite = onSprite;
        }
    }
    void OnTriggerStay2D(Collider2D collider){
        if (collider.CompareTag("Player") || collider.CompareTag("Hazards")){
            activeState = !invertStates;
            spr.sprite = onSprite; 
        }
    }
    // Set activeState to false when something leaves
    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player") || collider.CompareTag("Hazards")){
            activeState = invertStates;
            // Change sound and sprite
            sfx.clip = offSound;
            sfx.Play();
            spr.sprite = offSprite;
        }
    }

    void Update(){
        target.SetActive(activeState);
    }
}
