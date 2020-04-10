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
string tmp;
    public enum GridColor
    {
        yellow = 0,
        blue = 1,
        red = 2,
        green = 3
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
            gridScript gridScript = GameObject.Find("GridMap").GetComponent<gridScript>();
            gridPlacement gridPlacement = GameObject.Find("GridMap").GetComponent<gridPlacement>();
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
            switch (gridScript.selectedCharacter.name)
            {
                
                case "player1SlotA":
                    tmp = gridPlacement.leftA;
                    if (tmp == "")
                    {
                        Debug.LogError("String is empty");
                    }
                    displayRangeofMovement(gridPlacement.leftA);
                    break;
                case "player1SlotB":
                    displayRangeofMovement(gridPlacement.leftB);
                    break;
                case "player1SlotC":
                    displayRangeofMovement(gridPlacement.leftC);
                    break;
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

    public void displayRangeofMovement(string currentPosition)
    {
        int x, y;
        GameObject gridObject, grid;

        if (currentPosition == "")
        {
            Debug.LogError("String is empty");
            return;
        }

        char xChar = currentPosition[5];
        char yChar = currentPosition[7];
        x = (int)char.GetNumericValue(xChar);
        y = (int)char.GetNumericValue(yChar);

        grid = GameObject.Find("GridMap");
        gridObject = grid.transform.Find("Tile_" + (x - 1) + "_" + (y - 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + x + "_" + (y - 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 1) + "_" + (y - 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y - 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y - 2)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + (y - 1)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + y).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + (y + 1)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y + 2)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y + 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x + 1) + "_" + (y + 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + x + "_" + (y + 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x - 1) + "_" + (y + 3)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y + 2)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y + 1)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x - 3) + "_" + y).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y - 1)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];
        gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y - 2)).Find("hex_frame").gameObject;
        gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.green];


    }
}


