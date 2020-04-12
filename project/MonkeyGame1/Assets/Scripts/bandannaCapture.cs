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

        switch (playerSelect.currentCharacter)
        {
            case "A":
                playerStatus.leftA.hasBandana = true;
                playerStatus.bandannaRight.setParent(GameObject.Find("Player1SlotA"));
                // need to warp the bandnana as well in each case!!!!!!
                break;
            case "B":
                playerStatus.leftB.hasBandana = true;
                playerStatus.bandannaRight.setParent(GameObject.Find("Player1SlotB"));
                break;
            case "C":
                playerStatus.leftC.hasBandana = true;
                playerStatus.bandannaRight.setParent(GameObject.Find("Player1SlotC"));
                break;
            case "A2":
                playerStatus.rightA.hasBandana = true;
                playerStatus.bandannaRight.setParent(GameObject.Find("Player2SlotA"));
                break;
            case "B2":
                playerStatus.rightB.hasBandana = true;
                playerStatus.bandannaRight.setParent(GameObject.Find("Player2SlotB"));
                break;
            case "C2":
                playerStatus.rightC.hasBandana = true;
                playerStatus.bandannaRight.setParent(GameObject.Find("Player2SlotC"));
                break;
            default:
                break;
        }
        return;
    }


}
