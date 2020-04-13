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
                case "Player2SlotA":
                    playerStatus.leftA.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "Player2SlotB":
                    playerStatus.leftB.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "Player2SlotC":
                    playerStatus.leftC.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                default:
                    break;
            }
        }
        else
        {
            bandanna = playerStatus.bandannaRight;
            switch (attackedCharacter.name)
            {
                case "Player1SlotA":
                    playerStatus.rightA.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "Player1SlotB":
                    playerStatus.rightB.hasBandana = false;
                    giveBandannaToCurrent(bandanna);
                    break;
                case "Player1SlotC":
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
        GameObject gridObject = GameObject.Find("GridMap");

        switch (playerSelect.currentCharacter)
        {
            case "A":
                playerStatus.leftA.hasBandana = true;
                newParent = GameObject.Find("Player1SlotA");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                // need to warp the bandnana as well in each case!!!!!!
                playerStatus.bandannaRight.transform.position = gridObject.transform.Find(newParent.name).position;
                break;
            case "B":
                playerStatus.leftB.hasBandana = true;
                newParent = GameObject.Find("Player1SlotB");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                playerStatus.bandannaRight.transform.position = gridObject.transform.Find(newParent.name).position;
                break;
            case "C":
                playerStatus.leftC.hasBandana = true;
                newParent = GameObject.Find("Player1SlotC");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                playerStatus.bandannaRight.transform.position = gridObject.transform.Find(newParent.name).position;
                break;
            case "A2":
                playerStatus.rightA.hasBandana = true;
                newParent = GameObject.Find("Player2SlotA");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                playerStatus.bandannaLeft.transform.position = gridObject.transform.Find(newParent.name).position;
                break;
            case "B2":
                playerStatus.rightB.hasBandana = true;
                newParent = GameObject.Find("Player2SlotB");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                playerStatus.bandannaLeft.transform.position = gridObject.transform.Find(newParent.name).position;
                break;
            case "C2":
                playerStatus.rightC.hasBandana = true;
                newParent = GameObject.Find("Player2SlotC");
                playerStatus.bandannaRight.transform.SetParent(newParent.transform);
                playerStatus.bandannaLeft.transform.position = gridObject.transform.Find(newParent.name).position;
                break;
            default:
                break;
        }
        return;
    }

}
