using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeGridMaterial : MonoBehaviour
{

    public GameObject moveButton, hexPrefab, hexPrefabChild, attackButton;
    public Material[] materialList;
    public bool isBlue = false;
    
    GameObject grid;
    GameObject gridObject;
    int i, j;

    // Thus far this will execute when the moveButton is pressed.
    public void changeMaterial(){        
        
        grid = GameObject.Find("GridMap");

        // The attack button should be hidden if in movement mode, maybe in the future there should be a stand-alone script for this.
        attackButton.SetActive(false);

        hexPrefabChild = hexPrefab.transform.Find("hex_frame").gameObject;

        // Return to normal mode, grid becomes yellow.
        if(moveButton.GetComponentInChildren<Text>().text == "Confirm Move"){
             moveButton.GetComponentInChildren<Text>().text = "Move";
            moveButton.SetActive(false);
            for(i=0; i<=32; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    gridObject = grid.transform.Find("Tile_" + i + "_" + j).Find("hex_frame").gameObject;
                    gridObject.GetComponent<MeshRenderer>().material = materialList[0];
                }
            }
         //   hexPrefabChild.GetComponent<MeshRenderer>().material = materialList[0]; 
           // Debug.Log(hexPrefabChild.GetComponent<MeshRenderer>().sharedMaterial.name);
        }
        
       else{  // Enter Movement mode, grid becomes blue.
            moveButton.GetComponentInChildren<Text>().text = "Confirm Move";
            isBlue = true;
            for (i = 0; i <= 32; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    gridObject = grid.transform.Find("Tile_" + i + "_" + j).Find("hex_frame").gameObject;
                    gridObject.GetComponent<MeshRenderer>().material = materialList[1];
                }
            }
            //    hexPrefabChild.GetComponent<MeshRenderer>().sharedMaterial = materialList[1];
            //           Debug.Log(hexPrefabChild.GetComponent<MeshRenderer>().sharedMaterial.name);

        } 
      
    }
}


