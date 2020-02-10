using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform follow;
    public Vector2 offset;
    
    // Camera will follow the position of the 'follow' object
    // Keep offset values at 0 to keep the camera centered
    // Z axis position is -1 to ensure it's in front of the game scene
    void moveCamera(){
        transform.position = new Vector3 (follow.position.x + offset.x, follow.position.y + offset.y, -1);
    }

    // Update camera position every frame
    void Update()
    {
        moveCamera();
    }
}
