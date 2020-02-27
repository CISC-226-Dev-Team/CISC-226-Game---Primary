using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public string startScene;

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
