using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Planet_Scanner : MonoBehaviour
{

    // When the player enters the Scanner_Range trigger collider of a planet,
    // update the Planet_Scanner_GUI text accordingly
    // The planet's Scanner_Range child must have an accompanying tag to check for

    public TextMeshProUGUI scannerText;

    void OnTriggerEnter2D(Collider2D collider){
        // Upon entering a planet's scanner range, check the tag and update GUI text appropriately
        if (collider.tag == "Planet_Earth"){
            scannerText.text = "Entering Orbit:\nEarth\n\nPlanet Class:\nTerrestrial\n\nAtmosphere:\n75% Nitrogen\n15% Oxygen\n10% CO2\n\nClimate:\nWay hotter than it should be\n\nWarning!\nEcological collapse imminent";
        }
        else if (collider.tag == "Planet_0"){
            scannerText.text = "Entering Orbit:\nPlanet Zer0\n\nPlanet Class:\nTerrestrial\n\nAtmosphere:\n70% Nitrogen\n25% Oxygen\n5% CO2\n\nClimate:\nVery warm\n\nWarning!\nTectonic activity detected";
        }
        else if (collider.tag == "Planet_Underground_Level"){
            scannerText.text = "Entering Orbit: underground_level";
        }
        else if (collider.tag == "Planet_Ghost_Cavern"){
            scannerText.text = "Entering Orbit:\nSpectra-9\n\nPlanet Class:\nTerrestrial\n\nAtmosphere:\n80% Nitrogen\n12% Oxygen\n8% CO2\n\nClimate:\nCold on the surface, warmer underground\n\nWarning!\nDetecting deep, maze-like cave systems";
        }
        else if (collider.tag == "Sun"){
            scannerText.text = "Entering Orbit:\nSun\n\nStar Class:\nYellow Dwarf\n\nAtmosphere:\n75% Hydrogen\n25% Helium\n\nClimate:\nI mean it doesn't get much hotter than this\n\nWarning!\nWill expand into a red giant in like a billion years";
        }
    }   

    void OnTriggerExit2D(Collider2D collider){
        scannerText.text = "Scanning . . .";
    }   
}
