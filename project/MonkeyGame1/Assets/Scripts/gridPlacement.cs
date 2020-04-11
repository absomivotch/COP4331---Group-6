using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gridPlacement : MonoBehaviour
{
    GameObject playerObjects;
    GameObject gridObject;

    GameObject playerTeam1, playerTeam2;
    GameObject player1, player2, player3, player1Right, player2Right, player3Right;

    // For each of the character's positions.
    public static string leftA = "Tile_5_9", leftB = "Tile_7_5", leftC = "Tile_5_2", rightA = "Tile_26_5", rightB = "Tile_26_9", rightC = "Tile_25_3";
     
   // public int test = 44;

    void Start()
    {
        playerObjects = GameObject.Find("Level0Map");
        gridObject = GameObject.Find("GridMap");

        if (gridObject.transform.Find("Tile_0_0") != null)
        {
            playerTeam1 = playerObjects.transform.Find("Teams").Find("player1Team").gameObject;
            player1 = playerTeam1.transform.Find("player1SlotA").gameObject;
            player2 = playerTeam1.transform.Find("player1SlotB").gameObject;
            player3 = playerTeam1.transform.Find("player1SlotC").gameObject;

            player1.transform.position = gridObject.transform.Find("Tile_5_9").position;
            player2.transform.position = gridObject.transform.Find("Tile_7_5").position;
            player3.transform.position = gridObject.transform.Find("Tile_5_2").position;

            playerTeam2 = playerObjects.transform.Find("Teams").Find("player2Team").gameObject;
            player1Right = playerTeam2.transform.Find("player2SlotA").gameObject;
            player2Right = playerTeam2.transform.Find("player2SlotB").gameObject;
            player3Right = playerTeam2.transform.Find("player2SlotC").gameObject;

            player1Right.transform.position = gridObject.transform.Find("Tile_26_5").position;
            player2Right.transform.position = gridObject.transform.Find("Tile_26_9").position;
            player3Right.transform.position = gridObject.transform.Find("Tile_25_3").position;
        }
    }

    public bool checkHexOccupied(string hexTile){
        if(hexTile == leftA || hexTile == leftB || hexTile == leftC || hexTile == rightA || hexTile == rightB || hexTile == rightC)
            return true;
        return false;
    }

}
