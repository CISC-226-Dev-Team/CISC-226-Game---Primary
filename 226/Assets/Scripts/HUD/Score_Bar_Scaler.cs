using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Bar_Scaler : MonoBehaviour
{
    
    // Score related variables
    float score;
    float maxScore;

    // Update is called once per frame
    void Update()
    {
        // Get current HP every frame, calculate it as a % of max HP, scale the bar accordingly
        score = Player_Item_Interactions_Controller.score;
        maxScore = Player_Item_Interactions_Controller.numCoins;
        transform.localScale = new Vector3(score/maxScore,1,0);
    }

}
