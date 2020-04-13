using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandannaCapture : MonoBehaviour
{

    // Will take the bandanna from the chosenCharacter and give it to the attacking character.
    public void captureBandanna(GameObject attackedCharacter)
    {

        playerStatus playerStatus = GameObject.Find("GridMap").GetComponent<playerStatus>();
        playerSelect playerSelect = GameObject.Find("GameCamera").GetComponent<playerSelect>();
        GameObject bandanna;

        string currentCharacter = playerSelect.currentCharacter;

        if (playerStatus.turn == 1)
        { // attacking left team
            
            bandanna = playerStatus.bandannaLeft;
            switch (attackedCharacter.name)
            {
                case "player1SlotA":
                    playerStatus.leftA.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "player1SlotB":
                    playerStatus.leftB.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "player1SlotC":
                    playerStatus.leftC.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                default:
                    break;
            }
        }
        else
        {
            Debug.Log("42, attackedCharacter.name = " + attackedCharacter.name);
            bandanna = playerStatus.bandannaRight;
            switch (attackedCharacter.name)
            {
                
                case "player2SlotA":
                    playerStatus.rightA.hasBandana = false;
                    Debug.Log("48");
                    giveBandannaToCurrent(bandanna);
                    Debug.Log("50");
                    break;
                case "player2SlotB":
                    playerStatus.rightB.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "player2SlotC":
                    playerStatus.rightC.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                default:
                    break;
            }
        }
    }

    private void giveBandannaToCurrent(GameObject bandanna)
    {
        playerSelect playerSelect = GameObject.Find("GameCamera").GetComponent<playerSelect>();
        playerStatus playerStatus = GameObject.Find("GridMap").GetComponent<playerStatus>();
        GameObject newParent;
        GameObject gridObject = GameObject.Find("GridMap"), level0Map = GameObject.Find("Level0Map");
        GameObject team1level0Map = GameObject.Find("Level0Map/Teams/player1Team");
        GameObject team2level0Map = GameObject.Find("Level0Map/Teams/player2Team");

        switch (playerSelect.currentCharacter)
        {
            case "A":
                playerStatus.leftA.hasBandana = true;
                newParent = GameObject.Find("player1SlotA");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                // need to warp the bandnana as well in each case!!!!!!
                playerStatus.bandannaRight.transform.position = team1level0Map.transform.Find(newParent.name).position;
                break;
            case "B":
                playerStatus.leftB.hasBandana = true;
                newParent = GameObject.Find("player1SlotB");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                playerStatus.bandannaRight.transform.position = team1level0Map.transform.Find(newParent.name).position;
                break;
            case "C":
                playerStatus.leftC.hasBandana = true;
                newParent = GameObject.Find("player1SlotC");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                 playerStatus.bandannaRight.transform.position = team1level0Map.transform.Find(newParent.name).position;
                break;
            case "A2":
                playerStatus.rightA.hasBandana = true;
                newParent = GameObject.Find("player2SlotA");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                 playerStatus.bandannaRight.transform.position = team2level0Map.transform.Find(newParent.name).position;
                break;
            case "B2":
                playerStatus.rightB.hasBandana = true;
                newParent = GameObject.Find("player2SlotB");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                 playerStatus.bandannaRight.transform.position = team2level0Map.transform.Find(newParent.name).position;
                break;
            case "C2":
                playerStatus.rightC.hasBandana = true;
                newParent = GameObject.Find("player2SlotC");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                 playerStatus.bandannaRight.transform.position = team2level0Map.transform.Find(newParent.name).position;
                break;
            default:
                break;
        }
        return;
    }

}
