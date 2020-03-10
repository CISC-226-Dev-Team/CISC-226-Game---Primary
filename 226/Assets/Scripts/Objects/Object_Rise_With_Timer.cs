using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rise_With_Timer : MonoBehaviour
{
    // This causes the given object to expand vertically as a function of time remaining, in phase two

    // Score related variables
    float score;
    float maxScore;

    // Other values
    Game_Master gm;
    public float scaleSpeed;

    void Start(){
        gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
    }

    void Update()
    {
        // Count current coins every frame
        score = Player_Item_Interactions_Controller.score;
        maxScore = Player_Item_Interactions_Controller.numCoins;        
        // When phase two begin, start the rise
        if (gm.phaseTwo){
            // The water rises up to its full height at a rate of scale speed
            // Scale speed is multipled based on amount of time remaining: the lower the time left, the faster the scale speed
            transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(1,1,1), scaleSpeed * ((maxScore-score)/maxScore) * Time.deltaTime);
        }
    }
}
