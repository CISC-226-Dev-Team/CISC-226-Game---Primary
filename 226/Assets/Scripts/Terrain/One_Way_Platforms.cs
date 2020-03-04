using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Way_Platforms : MonoBehaviour
{

    PlatformEffector2D effector;

    void Start(){
        effector = GetComponent<PlatformEffector2D>();
    }

    // When holding down, the player can fall through the one way platforms
    void Update()
    {
        // When down is being held, the surface arc of the platforms becomes 0 (intangible)
        if (Input.GetKey(KeyCode.S)){
            effector.surfaceArc = 0f;
        }
        // Once released, it's set back to 90 degrees (collider only active from above)
        else{
            effector.surfaceArc = 90f;
        }
    }
}
