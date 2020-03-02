using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Hidden_Foreground : MonoBehaviour
{
    // This script is used on the foreground-tilemaps that you want to be hidden when the player enters them
    // That tilemap must have a tilemap-collider set to "is trigger"

    Tilemap tilemap;
    // Upon entry, the tilemap color will be changed from hiddenColor to revealedColor
    // Set the alpha level of revealedColor to 0 to make it completely transparent
    public Color hiddenColor;
    public Color revealedColor;

    void Start(){
        tilemap = GetComponent<Tilemap>();
        tilemap.color = hiddenColor;
    }

    // When the player enters the trigger collider space, de-activate the tilemap renderer
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Player"){
            tilemap.color = revealedColor;
        }
    }
    // When they exit, re-activate it
    void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Player"){
            tilemap.color = hiddenColor;
        }
    }
}
