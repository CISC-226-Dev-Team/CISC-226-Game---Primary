using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Self : MonoBehaviour
{
    // This script makes an object delete itself after a given time
    // timer determines how long that time is
    public float timer;
    float begin;

    void Start()
    {
        begin = 0f;
    }

    void Update()
    {
        begin += Time.deltaTime;
        if (begin >= timer){
            Destroy(gameObject);
        }
    }
}
