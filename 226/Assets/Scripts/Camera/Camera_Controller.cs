using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform follow;
    public Vector2 offset;

    // Music variables
    public AudioClip phaseOneMusic;
    public AudioClip phaseTwoMusic;
    Game_Master gm;
    AudioSource sfx;
    
    // Camera will follow the position of the 'follow' object
    // Keep offset values at 0 to keep the camera centered
    // Z axis position is -1 to ensure it's in front of the game scene
    void moveCamera(){
        transform.position = new Vector3 (follow.position.x + offset.x, follow.position.y + offset.y, -1);
    }

    // Determine background music based on current phase
    void Awake(){
        gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        sfx = GetComponent<AudioSource>();
        if (gm.phaseTwo){
            sfx.clip = phaseTwoMusic;
        }
        else{
            sfx.clip = phaseOneMusic;
        }
        sfx.loop = true;
        sfx.Play();
    }

    // Update camera position every frame
    void Update()
    {
        moveCamera();
        // Check if phase two has been entered and update the music accordingly
        if (gm.phaseTwo){
            sfx.clip = phaseTwoMusic;
            if (!sfx.isPlaying){
                sfx.Play();
            }
        }
    }
}
