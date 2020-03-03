using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompt_Changer : MonoBehaviour
{
    // Controls the text prompt on the Player HUD
    // When the trigger space is entered, activate the prompt and change its text to enterText
    // The prompt is disabled when not in such an area
    public string enterText;

    // Make sure to drag the Prompts and Prompts-Text objects from the GUI in here
    public GameObject prompt;
    public TextMeshProUGUI message;

    // Activate prompt and change text on entry
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            prompt.SetActive(true);
            message.text = enterText;
        }
    }

    // Deactivate prompt on exit
    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            prompt.SetActive(false);
        }
    }
}
