using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public string startScene;

    // Allow the player to return to the primary screen at any time by pressing ESC
    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            // Iterate through all children. Deactivate everything that isnt the background and the primary screen
            foreach (Transform child in transform){
                if (child.tag == "Main-Menu-Background"){
                    child.gameObject.SetActive(true);
                }
                else if (child.tag == "Main-Menu-Screen"){
                    child.gameObject.SetActive(true);
                }
                else{
                    child.gameObject.SetActive(false);
                }
            }
        }
    }   

    // Attach the following functions as OnClick events in the main menu's button objects

    // Loads the given 'start' scene when the start button is pressed
    public void start(){
        SceneManager.LoadScene(startScene);
    }

    // Exit the game when the exit button is pressed
    public void exit(){
        Application.Quit();
    }


}
