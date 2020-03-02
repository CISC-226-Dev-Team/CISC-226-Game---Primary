using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{
    // This will handle the scene transitions 
    // Requires that a Fading-Panel object (its a prefab) be at the top of the scene's GUI canvas
    // You must drag that Fading-Panel object into this object's transition animator for this to work
    public Animator transitionAnimator;
    // escScene determines which scene to load into after the transition animation is complete
    public string escScene;
    
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
