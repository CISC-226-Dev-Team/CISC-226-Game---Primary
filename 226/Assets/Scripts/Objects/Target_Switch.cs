using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Switch : MonoBehaviour
{
    // Target switch toggles its active state when it gets shot

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

    void Start(){
        target.SetActive(activeState);
        sfx = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Whenever a bullet hits the target, toggle the active state
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player_Bullet" || collision.gameObject.tag == "Enemy_Bullet"){
            // Swap active state
            activeState = !activeState;
            // Apply change
            target.SetActive(activeState);
            // Play sounds / do sprite changes
            if (activeState){
                sfx.clip = offSound;
                spr.sprite = offSprite;
            }
            else{
                sfx.clip = onSound;
                spr.sprite = onSprite;
            }
            sfx.Play();
        }
    }

}
