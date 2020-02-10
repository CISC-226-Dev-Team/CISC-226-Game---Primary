using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // If the player is dead, activate the Game_Over_Screen child object
        if (!Player_Health_and_Damage_Controller.isAlive){
            transform.Find("Game Over Screen").gameObject.SetActive(true);
        }
    }
}