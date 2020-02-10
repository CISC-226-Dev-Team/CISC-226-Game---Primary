using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Number_Getter : MonoBehaviour
{
    // Health related variables
    float currentHP;
    float maxHP;
    // Text field
    Text txt;

    void Start(){
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get health point info and update the text field
        maxHP = Player_Health_and_Damage_Controller.maxHealthPoints;
        currentHP = Player_Health_and_Damage_Controller.currentHealthPoints;
        txt.text = currentHP.ToString() + " / " + maxHP.ToString();
        
    }

}
