using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeGridMaterial : MonoBehaviour
{

    public GameObject moveButton, hexPrefab, hexPrefabChild, attackButton, specificHex;
    public Material[] materialList;
    public bool isBlue = false, exemptHex = false;
    //public string[] exemptHexs = new string[3];
    public string exemptHexName;

    GameObject grid;
    GameObject gridObject;
    int i, j;

    public enum GridColor
    {
        yellow = 0,
        blue = 1,
        red = 2
    }



    // Thus far this will execute when the moveButton is pressed. It will turn the grid  blue.
    public void changeMaterial()
    {
        exemptHex = false;

        Debug.Log("changeMaterial Called");

        grid = GameObject.Find("GridMap");

        // The attack button should be hidden if in movement mode, maybe in the future there should be a stand-alone script for this.
        attackButton.SetActive(false);

        hexPrefabChild = hexPrefab.transform.Find("hex_frame").gameObject;

        // Return to normal mode, grid becomes yellow.
        if (moveButton.GetComponentInChildren<Text>().text == "Confirm Move")
        {

            gridScript gridScript = GameObject.Find("GridMap").GetComponent<gridScript>();
            gridScript.warp(exemptHexName);
            gridScript.choseATile = false;

            moveButton.GetComponentInChildren<Text>().text = "Move";
            moveButton.SetActive(false);

            for (i = 0; i <= 32; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    specificHex = grid.transform.Find("Tile_" + i + "_" + j).gameObject;
                    gridObject = grid.transform.Find("Tile_" + i + "_" + j).Find("hex_frame").gameObject;
                    gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.yellow];
                }
            }

        }

        else
        {  // Enter Movement mode, grid becomes blue.
            moveButton.GetComponentInChildren<Text>().text = "Confirm Move";
            isBlue = true;
            
            for (i = 0; i <= 32; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    specificHex = grid.transform.Find("Tile_" + i + "_" + j).gameObject;
                    gridObject = grid.transform.Find("Tile_" + i + "_" + j).Find("hex_frame").gameObject;

                    if (exemptHexName == specificHex.name)
                    {
                        exemptHex = true;
                    }

                    if (exemptHex == false)
                    {
                        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.blue];
                    }
                    exemptHex = false;
                }
            }
        }

    }
    public void changeHexRed(int x, int y)
    {
        GameObject gridObject, grid;

        grid = GameObject.Find("GridMap");
        gridObject = grid.transform.Find("Tile_" + x + "_" + y).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
    }

    public void changeHexBlue(int x, int y)
    {
        GameObject gridObject, grid;

        grid = GameObject.Find("GridMap");
        gridObject = grid.transform.Find("Tile_" + x + "_" + y).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.blue];
    }
}


