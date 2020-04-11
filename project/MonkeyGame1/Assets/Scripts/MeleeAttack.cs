using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{

    public bool chooseA = false, chooseB = false, chooseC = false;
    // Should be executed when the player selects the Melee button.
    public void meleeAttack()
    {

        gridPlacement gridPlacement = GameObject.Find("GridMap").GetComponent<gridPlacement>();
        gridScript gridScript = GameObject.Find("GridMap").GetComponent<gridScript>();
        stringTileToIntCoords stringTileToIntCoords = GameObject.Find("GridMap").GetComponent<stringTileToIntCoords>();
        playerSelect playerSelect = GameObject.Find("GameCamera").GetComponent<playerSelect>();
        playerStatus playerStatus = GameObject.Find("GridMap").GetComponent<playerStatus>();
        string currentPosition, enemyApos, enemyBpos, enemyCpos;
        int currentX, currentY;
        List<string> surroundingTiles = new List<string>();
        bool AisOK = false, BisOK = false, CisOK = false;
        GameObject meleeButton = GameObject.Find("MeleeButton"), infoBar = GameObject.Find("InfoBar"), chosenEnemy;
        GameObject gridObject = GameObject.Find("GridMap");


        if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
        {
            if (playerStatus.turn == 1)
            {
                switch (playerSelect.meleeingCharacter)
                {
                    case "A":
                        Debug.Log("meleeing A");
                        if (AisOK)
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's A player";
                            chooseA = true;
                            chooseB = false;
                            chooseC = false;
                        }
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        break;
                    case "B":
                        Debug.Log("meleeing B");
                        if (BisOK)
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's B player";
                            chooseA = false;
                            chooseB = true;
                            chooseC = false;
                        }
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        break;
                    case "C":
                        Debug.Log("meleeing C");
                        if (CisOK)
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's C player";
                            chooseA = false;
                            chooseB = false;
                            chooseC = true;
                        }
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (playerSelect.meleeingCharacter)
                {
                    case "A2":
                        Debug.Log("meleeing A2");
                        if (AisOK)
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's A player";
                            chooseA = true;
                            chooseB = false;
                            chooseC = false;
                        }
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        break;
                    case "B2":
                    Debug.Log("meleeing B2");
                        if (BisOK)
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's B player";
                            chooseA = false;
                            chooseB = true;
                            chooseC = false;
                        }
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        break;
                    case "C2":
                        Debug.Log("meleeing C2");
                        if (CisOK)
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's C player";
                            chooseA = false;
                            chooseB = false;
                            chooseC = true;
                        }
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        break;
                    default:
                        break;
                }
            }
            // Make call to doMelee function.
            if (chooseA)
                doMelee("A");
            if (chooseB)
                doMelee("B");
            if (chooseC)
                doMelee("C");

            chooseA = false;
            chooseB = false;
            chooseC = false;

            meleeButton.GetComponentInChildren<Text>().text = "Melee";
            meleeButton.SetActive(false);
        }

        // Clicked Melee button when text is Melee
        if (meleeButton.GetComponentInChildren<Text>().text == "Melee")
        {

            Debug.Log("here");
            meleeButton.GetComponentInChildren<Text>().text = "Confirm Melee";


            // Check to see if another monkey of the oposing team is next to your currently selected character.

            // Find the current position of currently selected monkey.
            switch (playerSelect.currentCharacter)
            {
                case "A":
                    currentPosition = gridPlacement.leftA;
                    break;
                case "B":
                    currentPosition = gridPlacement.leftB;
                    break;
                case "C":
                    currentPosition = gridPlacement.leftC;
                    break;
                case "A2":
                    currentPosition = gridPlacement.rightA;
                    break;
                case "B2":
                    currentPosition = gridPlacement.rightB;
                    break;
                case "C2":
                    currentPosition = gridPlacement.rightC;
                    break;
                default:
                    currentPosition = "Tile_0_0";
                    break;
            }

            currentX = stringTileToIntCoords.getXposition(currentPosition);
            currentY = stringTileToIntCoords.getYposition(currentPosition);

            Debug.Log("currentPosInMelee = " + currentX + ", " + currentY);

            // Find positions of enemies.
            if (playerStatus.turn == 0)
            {
                enemyApos = gridPlacement.rightA;
                enemyBpos = gridPlacement.rightB;
                enemyCpos = gridPlacement.rightC;
            }
            else
            {
                enemyApos = gridPlacement.leftA;
                enemyBpos = gridPlacement.leftB;
                enemyCpos = gridPlacement.leftB;
            }

            // Compile list of surroindg tiles.
            if (currentY % 2 == 0)// even hex row
            {
                surroundingTiles.Add("Tile_" + currentX + "_" + (currentY + 1));
                surroundingTiles.Add("Tile_" + (currentX - 1) + "_" + (currentY + 1));
                surroundingTiles.Add("Tile_" + (currentX - 1) + "_" + currentY);
                surroundingTiles.Add("Tile_" + (currentX - 1) + "_" + (currentY - 1));
                surroundingTiles.Add("Tile_" + currentX + "_" + (currentY - 1));
                surroundingTiles.Add("Tile_" + (currentX + 1) + "_" + currentY);
            }
            else
            {// odd hex row
                surroundingTiles.Add("Tile_" + (currentX + 1) + "_" + (currentY + 1));
                surroundingTiles.Add("Tile_" + currentX + "_" + (currentY + 1));
                surroundingTiles.Add("Tile_" + (currentX - 1) + "_" + currentY);
                surroundingTiles.Add("Tile_" + currentX + "_" + (currentY - 1));
                surroundingTiles.Add("Tile_" + (currentX + 1) + "_" + (currentY - 1));
                surroundingTiles.Add("Tile_" + (currentX + 1) + "_" + currentY);
            }

            // Loop thru surrounding tiles to see if any ememyPositions conflict, if so mark that.
            for (int i = 0; i < 6; i++)
            {
                if (enemyApos == surroundingTiles[i])
                {
                    AisOK = true;
                    Debug.Log("AisOK");
                }
                if (enemyBpos == surroundingTiles[i])
                {
                    BisOK = true;
                    Debug.Log("BisOK");
                }
                if (enemyCpos == surroundingTiles[i])
                {
                    CisOK = true;
                    Debug.Log("CisOK");
                }
            }
        }

        void doMelee(string chosenCharacter)
        {
            // Clicked Melee button when text is confirm melee.
            if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
            {

                meleeButton.GetComponentInChildren<Text>().text = "Melee";

                if (playerStatus.turn == 1)
                {
                    if (chosenCharacter == "A")
                    {
                        chosenEnemy = GameObject.Find("player1SlotA");
                        playerStatus.leftA.isCaptured = true;
                        // Send to barrel.
                        infoBar.GetComponentInChildren<Text>().text = "Sent left's A player to the monkey barrel!";
                        chosenEnemy.transform.position = gridObject.transform.Find("Tile_27_7").position;
                    }
                    if (chosenCharacter == "B")
                    {
                        chosenEnemy = GameObject.Find("player1SlotB");
                        playerStatus.leftA.isCaptured = true;
                        // Send to barrel.
                        infoBar.GetComponentInChildren<Text>().text = "Sent left's B player to the monkey barrel!";
                        chosenEnemy.transform.position = gridObject.transform.Find("Tile_27_7").position;
                    }
                    if (chosenCharacter == "C")
                    {
                        chosenEnemy = GameObject.Find("player1SlotC");
                        playerStatus.leftA.isCaptured = true;
                        // Send to barrel.
                        infoBar.GetComponentInChildren<Text>().text = "Sent left's C player to the monkey barrel!";
                        chosenEnemy.transform.position = gridObject.transform.Find("Tile_27_7").position;
                    }
                }
                else
                {
                    if (chosenCharacter == "A")
                    {
                        chosenEnemy = GameObject.Find("player2SlotA");
                        playerStatus.leftA.isCaptured = true;
                        // Send to barrel.
                        infoBar.GetComponentInChildren<Text>().text = "Sent rights's A player to the monkey barrel!";
                        chosenEnemy.transform.position = gridObject.transform.Find("Tile_2_7").position;
                    }
                    if (chosenCharacter == "B")
                    {
                        chosenEnemy = GameObject.Find("player2SlotB");
                        playerStatus.leftA.isCaptured = true;
                        // Send to barrel.
                        infoBar.GetComponentInChildren<Text>().text = "Sent rights's B player to the monkey barrel!";
                        chosenEnemy.transform.position = gridObject.transform.Find("Tile_2_7").position;
                    }
                    if (chosenCharacter == "C")
                    {
                        chosenEnemy = GameObject.Find("player2SlotC");
                        playerStatus.leftA.isCaptured = true;
                        // Send to barrel.
                        infoBar.GetComponentInChildren<Text>().text = "Sent rights's C player to the monkey barrel!";
                        chosenEnemy.transform.position = gridObject.transform.Find("Tile_2_7").position;
                    }
                }
            }

            meleeButton.SetActive(false);
            GameObject.Find("FireButton").SetActive(false);

        }
    }
}