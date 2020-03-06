using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Move_Forward : MonoBehaviour
{
    public float projectileVelocity;
    public float activeTime;
    float timeAtLaunch;
    Rigidbody2D rb;

    void Awake()
    {
        // Track the time when the projectile is created so we know when to destroy it later
        timeAtLaunch = Time.time;
        // Gravity scale and linear drag should be 0 so that the velocity stays constant
        rb = GetComponent<Rigidbody2D>();
    }

    public void setDirection(int dir){ // dir = -1 for left, +1 for right
        // Set the projectile's velocity
        rb.velocity = new Vector2(projectileVelocity*dir,0);
    }

    // Destroy the bullet if it impacts an object
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

    // Check if the object has expired every frame
    void Update()
    {
        if (Time.time - timeAtLaunch > activeTime){
            Destroy(gameObject);
        }
    }
}
