using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeGridMaterial : MonoBehaviour
{

    public GameObject moveButton, hexPrefab, hexPrefabChild, attackButton;
    public Material[] materialList;

     // Thus far this will execute when the moveButton is pressed.
    public void changeMaterial(){        
        
        // The attack button should be hidden if in movement mode, maybe in the future there should be a stand-alone script for this.
        attackButton.SetActive(false);

        hexPrefabChild = hexPrefab.transform.Find("hex_frame").gameObject;

        // Return to normal mode, grid becomes yellow.
        if(moveButton.GetComponentInChildren<Text>().text == "Confirm Move"){
             moveButton.GetComponentInChildren<Text>().text = "Move";
             moveButton.SetActive(false);

             hexPrefabChild.GetComponent<MeshRenderer>().material = materialList[0];    
        }
        
       else{  // Enter Movement mode, grid becomes blue.
            moveButton.GetComponentInChildren<Text>().text = "Confirm Move";
            hexPrefabChild.GetComponent<MeshRenderer>().material = materialList[1];
       } 
      
    }
}


