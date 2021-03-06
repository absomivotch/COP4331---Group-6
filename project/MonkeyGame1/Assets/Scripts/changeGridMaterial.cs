﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;


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
                    displayRangeofMovement(gridPlacement.leftA);
                    break;
                case "player1SlotB":
                    displayRangeofMovement(gridPlacement.leftB);
                    break;
                case "player1SlotC":
                    displayRangeofMovement(gridPlacement.leftC);
                    break;
                case "player2SlotA":
                    displayRangeofMovement(gridPlacement.rightA);
                    break;
                case "player2SlotB":
                    displayRangeofMovement(gridPlacement.rightB);
                    break;
                case "player2SlotC":
                    displayRangeofMovement(gridPlacement.rightC);
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
        string stringOfNumbers, strX, strY;

        GameObject gridObject, grid;

        if (currentPosition == "")
        {
            Debug.LogError("String is empty in displayRangeOfMovement");
            return;
        }

        Debug.Log("Incomming string = " + currentPosition);

        stringOfNumbers = currentPosition.Substring(5);

        List<string> myList = stringOfNumbers.Split('_').ToList();

        strX = myList[0];
        strY = myList[1];

        x = int.Parse(strX);
        y = int.Parse(strY);


        // Debug.Log("Calculated center = ( " + x + "," + y + ")");

        grid = GameObject.Find("GridMap");
        // For odd numbered rows:
        if (y % 2 != 0)
        {
            if (checkCoordsOnBoader(x - 1, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 1) + "_" + (y - 3)).Find("hex_frame").gameObject;
                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + x + "_" + (y - 3)).Find("hex_frame").gameObject;
                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 1, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 1) + "_" + (y - 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y - 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y - 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y - 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 3, y - 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + (y - 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 3, y))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + y).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 3, y + 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + (y + 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y + 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y + 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 1, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 1) + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + x + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 1, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 1) + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y + 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y + 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y + 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y + 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 3, y))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 3) + "_" + y).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y - 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y - 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y - 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y - 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
        }
        // For even rows:
        else
        {
            if (checkCoordsOnBoader(x - 1, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 1) + "_" + (y - 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + x + "_" + (y - 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 1, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 1) + "_" + (y - 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x, y - 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y - 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y - 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y - 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y - 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y - 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 3, y))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 3) + "_" + y).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 1, y + 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y + 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 2, y + 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 2) + "_" + (y + 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x + 1, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x + 1) + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + x + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 1, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 1) + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y + 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y + 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 3, y + 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 3) + "_" + (y + 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 3, y))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 3) + "_" + y).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 3, y - 1))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 3) + "_" + (y - 1)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y - 2))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y - 2)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
            if (checkCoordsOnBoader(x - 2, y + 3))
            {
                gridObject = grid.transform.Find("Tile_" + (x - 2) + "_" + (y + 3)).Find("hex_frame").gameObject;

                gridObject.GetComponent<MeshRenderer>().material = materialList[(int)GridColor.red];
            }
        }
    }

    bool checkCoordsOnBoader(int x, int y)
    {
        if (x > 0 && x <= 31 & y >= 0 && y <= 12)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

