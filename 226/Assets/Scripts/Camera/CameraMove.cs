using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = Camera.main.orthographicSize*0.15f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(cameraSpeed*-1,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(cameraSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0,cameraSpeed,0);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0,cameraSpeed*-1,0);
        }
        
        if (Input.GetKey(KeyCode.A)){
            Camera.main.orthographicSize += 0.25f;
        }
        if (Input.GetKey(KeyCode.S)){
            Camera.main.orthographicSize -= 0.25f;
        }
    }
}
