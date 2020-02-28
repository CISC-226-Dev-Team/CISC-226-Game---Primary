using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spinning : MonoBehaviour
{

    public float rotationSpeed;

    // Rotate the object every frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
