using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Number_Getter : MonoBehaviour
{
    // Score related variables
    float score;
    float maxScore;
    // Text field
    Text txt;

    void Start(){
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get health point info and update the text field
        score = Player_Item_Interactions_Controller.score;
        maxScore = Player_Item_Interactions_Controller.numCoins;
        txt.text = score.ToString() + " / " + maxScore.ToString();
        
    }
}
