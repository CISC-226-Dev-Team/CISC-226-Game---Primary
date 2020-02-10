using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_Scaler : MonoBehaviour
{

    // Health related variables
    float currentHP;
    float maxHP;

    // Update is called once per frame
    void Update()
    {
        // Get current HP every frame, calculate it as a % of max HP, scale the bar accordingly
        maxHP = Player_Health_and_Damage_Controller.maxHealthPoints;
        currentHP = Player_Health_and_Damage_Controller.currentHealthPoints;
        transform.localScale = new Vector3(currentHP/maxHP,1,0);
    }

}
