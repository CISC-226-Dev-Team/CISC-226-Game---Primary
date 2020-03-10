using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{
    // This will handle the scene transitions 
    // Requires that a Fading-Panel object (it's a prefab) be at the end of the scene's GUI Canvas
    // IMPORTANT: Every Scene's GUI Canvas MUST BE NAMED EXACTLY "GUI Canvas" for this to work
    Animator transitionAnimator;
    // escScene determines which scene to load into after the transition animation is complete
    // This should be passed by the Trigger_Change_Scene script (or any other script that changes scenes) when it's activated
    public string escScene;
    
    void Start(){
        // Get the Fading-Panel animator
        transitionAnimator = GameObject.Find("GUI Canvas").transform.Find("Fading-Panel").GetComponent<Animator>();
        // Default escScene to Main Menu, in case transition() somehow gets called without being passed a scene to load into
        escScene = "Main_Menu";
    }

    // This function allows for buttons to change the escScene
    public void setScene(string sceneName){
        escScene = sceneName;
    }

    public void transition(){
        StartCoroutine(LoadScene());
    }

    // Transition coroutine
    IEnumerator LoadScene(){
        // Start the fade_out animation, wait for it to complete, then load the chosen scene
        transitionAnimator.SetTrigger("Fade_Out");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(escScene);
    }
}
