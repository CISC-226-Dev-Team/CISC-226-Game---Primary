using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Toggle_Active : MonoBehaviour
{
    // This simple switch toggles whether a given object is active or not when the player uses it

    // The game object to be toggled
    public GameObject target;
    public bool activeState;

    // Toggling the switch also has sound effects and different sprites
    AudioSource sfx;
    public AudioClip onSound;
    public AudioClip offSound;
    SpriteRenderer spr;
    public Sprite onSprite;
    public Sprite offSprite;

    // To track if the player is close enough to press the switch:
    bool isNear;

    void Start(){
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
        // Initialize isNear to false
        isNear = false;
    }

    // Set isNear to true when the player enters the trigger space, and false when they exit
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            isNear = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            isNear = false;
        }
    }

    void Update(){
        // Allow the player to toggle the switch when nearby
        if (Input.GetKeyDown(KeyCode.E) && isNear){
                // Toggle active state, sound clip and sprite
                if (activeState){
                    activeState = false;
                    sfx.clip = offSound;
                    spr.sprite = offSprite;
                }
                else{
                    activeState = true;
                    sfx.clip = onSound;
                    spr.sprite = onSprite;
                }
                // Apply activeState to target object
                target.SetActive(activeState);
                // Play switch sound
                sfx.Play();
            }
    }
}
