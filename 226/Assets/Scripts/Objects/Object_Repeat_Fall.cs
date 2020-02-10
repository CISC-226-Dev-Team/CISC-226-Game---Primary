using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Repeat_Fall : MonoBehaviour
{

    // Causes the object to fall at a set speed, then teleport back to its starting position after falling a certain distance
    public float fallSpeed;
    public float fallDistance;
    Vector2 startingPosition;

    void Start(){
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,fallSpeed * -1 * Time.deltaTime,0);
        if (startingPosition.y - transform.position.y >= fallDistance){
            transform.position = startingPosition;
        }
    }
}
