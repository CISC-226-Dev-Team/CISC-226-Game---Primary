using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Test : MonoBehaviour
{

    BoxCollider2D boxCollider;
    public float distance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 positionLeft = new Vector2(transform.position.x-(boxCollider.size.x), transform.position.y);
        Vector2 positionRight = new Vector2(transform.position.x+(boxCollider.size.x), transform.position.y);
        Vector2 positionBottomLeft = new Vector2(transform.position.x-(boxCollider.size.x), transform.position.y-distance);
        Vector2 positionBottomRight = new Vector2(transform.position.x+(boxCollider.size.x), transform.position.y-distance);
        Debug.DrawLine(positionLeft,positionBottomLeft,Color.red,0.01f,false);
        Debug.DrawLine(positionRight,positionBottomRight,Color.blue,0.01f,false);
        */
        Vector2 pos1 = new Vector2(transform.position.x,transform.position.y);
        Vector2 pos2 = new Vector2(transform.position.x,transform.position.y-(boxCollider.size.y*transform.localScale.y*0.5f));
        Debug.DrawLine(pos1,pos2,Color.red,0.01f,false);
        
    }
}
