using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rise_With_Timer : MonoBehaviour
{
    // This causes the given object to expand vertically as a function of time remaining, in phase two

    // Score related variables
    float score;
    bool coinsChecked;
    float timer;

    Game_Master gm;

    Vector3 start = new Vector3(1,0,1);
    Vector3 end = new Vector3(1,1,1);

    void Start(){
        gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        coinsChecked = false;
        timer = 0f;
    }

    void Update()
    {
        if (gm.phaseTwo){
            // Upon phase two beginning, check number of coins collected
            if (!coinsChecked){
                score = Player_Item_Interactions_Controller.score;
                coinsChecked = true;
            }
            // The water will smoothly rise from 0% to 100% over the course of *score* seconds
            timer += Time.deltaTime/score;
            transform.localScale = Vector3.Lerp(start, end, timer);
        }
    }
}
