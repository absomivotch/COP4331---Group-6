using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeGridMaterial : MonoBehaviour
{

    public GameObject moveButton, hexPrefab, hexPrefabChild, attackButton;
    public Material[] materialList;
    public bool isBlue = false, exemptHex = false;
    public string[] exemptHexs = new string[3];

    GameObject grid;
    GameObject gridObject;
    int i, j;

    public enum GridColor
    {
        yellow = 0,
        blue = 1,
        green = 2
    }



    // Thus far this will execute when the moveButton is pressed. It will turn the grid  blue.
    public void changeMaterial()
    {
        grid = GameObject.Find("GridMap");

        // The attack button should be hidden if in movement mode, maybe in the future there should be a stand-alone script for this.
        attackButton.SetActive(false);

        hexPrefabChild = hexPrefab.transform.Find("hex_frame").gameObject;

        // Return to normal mode, grid becomes yellow.
        if (moveButton.GetComponentInChildren<Text>().text == "Confirm Move")
        {
           
            gridScript gridScript = GameObject.Find("GridMap").GetComponent<gridScript>();
            gridScript.numberOfChosenTiles = 0;
            Debug.Log("numberOfChosenTiles = 0");
        
            moveButton.GetComponentInChildren<Text>().text = "Move";
            moveButton.SetActive(false);

            for(int h = 0; h <3; h++){
                Debug.Log("exemptHexs[" + h + "] =" + exemptHexs[h]);
            }
            
            for (i = 0; i <= 32; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    gridObject = grid.transform.Find("Tile_" + i + "_" + j).Find("hex_frame").gameObject;
                    for (int k = 0; k < 3; k++)
                    {
                        if (exemptHexs[k] == gridObject.name)
                        {
                            exemptHex = true;
                        }
                    }
                    if (exemptHex == false)
                    {
                        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.yellow];
                    }
                    exemptHex = false;
                }
            }
           
       
            //   hexPrefabChild.GetComponent<MeshRenderer>().material = materialList[0]; 
            // Debug.Log(hexPrefabChild.GetComponent<MeshRenderer>().sharedMaterial.name);
        }

        else
        {  // Enter Movement mode, grid becomes blue.
            moveButton.GetComponentInChildren<Text>().text = "Confirm Move";
            isBlue = true;
            for (i = 0; i <= 32; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    gridObject = grid.transform.Find("Tile_" + i + "_" + j).Find("hex_frame").gameObject;
                     for (int k = 0; k < 3; k++)
                    {
                        if (exemptHexs[k] == gridObject.name)
                        {
                            exemptHex = true;
                        }
                    }
                    if (exemptHex == false)
                    {
                        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.blue];
                    }
                    exemptHex = false;
                }
            }
            //    hexPrefabChild.GetComponent<MeshRenderer>().sharedMaterial = materialList[1];
            //           Debug.Log(hexPrefabChild.GetComponent<MeshRenderer>().sharedMaterial.name);

        }

    }
    public void changeHexGreen(int x, int y)
    {
        GameObject gridObject, grid;

        grid = GameObject.Find("GridMap");
        gridObject = grid.transform.Find("Tile_" + x + "_" + y).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
    }
}


