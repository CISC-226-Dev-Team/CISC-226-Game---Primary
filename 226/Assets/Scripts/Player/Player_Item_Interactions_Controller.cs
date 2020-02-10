using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item_Interactions_Controller : MonoBehaviour
{

    // Scoring variables
    public static int score;
    public static int numCoins;

    void Start(){
        // Count number of coins on start
        numCoins = GameObject.Find("Coins").transform.childCount;
    }

    // Reset score to last checkpoint
    void Awake(){
        Game_Master gm = GameObject.Find("GameMaster").GetComponent<Game_Master>();
        score = gm.respawnScore;
    }

    // Whenever an object with a trigger hitbox is touched, check what it is and resolve accordingly by checking tags
    void OnTriggerEnter2D(Collider2D collision){

        // Coins increase score by 1, then disappear
        if (collision.CompareTag("Item_Coin")){
            score += 1;
            Destroy(collision.gameObject);
        }

        // Medkits restore 5 health, up to the maximum, then disappear
        else if (collision.CompareTag("Item_Medkit")){
            if (Player_Health_and_Damage_Controller.currentHealthPoints < Player_Health_and_Damage_Controller.maxHealthPoints){
                Player_Health_and_Damage_Controller.currentHealthPoints += 5;
                Destroy(collision.gameObject);
            }
        }

    }

}
