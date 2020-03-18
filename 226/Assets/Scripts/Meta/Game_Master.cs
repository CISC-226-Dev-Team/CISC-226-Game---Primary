using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Master : MonoBehaviour
{
    // The Game_Master handles respawning and level resetting
    private static Game_Master instance;
    // All relevant values are tracked here, preserved between level reloads
    public Vector2 respawnLocation;
    public int respawnHealthPoints;
    public int respawnScore;
    public bool phaseTwo;
    public bool checkpointed;

    // Phase grid objects
    public GameObject phase_one;
    public GameObject phase_two;

    // Positions are now saved in the space screen too!
    public Vector2 shipLocation;
    // Any additional values that need to stay constant through scene reloads can be stored here

    void Awake(){
        // Create an instance of GameMaster if there isnt one already
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }
        // if there is, destroy it to prevent multiple game masters from existing
        else{
            Destroy(gameObject);
        }
    }

    void Start(){
        // Get the phase grid objects and activate/deactivate as needed
        phase_one = GameObject.FindWithTag("Grid_Phase_One");
        phase_two = GameObject.FindWithTag("Grid_Phase_Two");

        if (phase_one != null){
            if (checkpointed){
                // De-activate phase one
                phase_one.SetActive(false);
                // Activate phase-two
                phase_two.SetActive(true);
            }
            else{
                phase_two.SetActive(false);
            }
        }
        
    }
}
