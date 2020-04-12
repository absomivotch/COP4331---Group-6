using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerSelect : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;

    public GameObject moveButton, attackButton, meleeButton, fireButton, infoBar;
    public static string currentCharacter = "none", meleeingCharacter = "none";

    void Update()
    {
        infoBar = GameObject.Find("InfoBar");
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            playerStatus playerStatus = GameObject.Find("GridMap").GetComponent<playerStatus>();
            gridScript gridScript = GameObject.Find("GridMap").GetComponent<gridScript>();

            // Click the character you want to play as, esnure that you're not already in movement mode.
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {

                if (hit.collider.name == "player1SlotA")
                {
                    // Melee Mode
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = "A";
                        if(playerStatus.AisOK && playerStatus.turn == 1){
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's A player";
                        }
                        else if(!playerStatus.AisOK && playerStatus.turn == 1){
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        }
                    }
                    else
                    {
                        currentCharacter = "A";

                        if (gridScript.selectedCharacter == GameObject.Find("player1SlotA")) // double check with grid script
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Left Player A Selected";
                            if (playerStatus.leftA.moved == false)
                                moveButton.SetActive(true);
                            if (playerStatus.leftA.attacked == false)
                                attackButton.SetActive(true);
                        }
                    }

                }
                if (hit.collider.name == "player1SlotB")
                {

                    // Melee Mode
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = "B";
                        if(playerStatus.BisOK && playerStatus.turn == 1){
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's A player";
                        }
                        else if(!playerStatus.BisOK && playerStatus.turn == 1){
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        }
                    }
                    else
                    {
                        currentCharacter = "B";

                        if (gridScript.selectedCharacter == GameObject.Find("player1SlotB"))
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Left Player B Selected";
                            if (playerStatus.leftB.moved == false)
                                moveButton.SetActive(true);
                            if (playerStatus.leftB.attacked == false)
                                attackButton.SetActive(true);

                        }
                    }
                }
                if (hit.collider.name == "player1SlotC")
                {
                    // Melee Mode
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = "C";
                        if(playerStatus.CisOK && playerStatus.turn == 1){
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's C player";
                        }
                        else if(!playerStatus.CisOK && playerStatus.turn == 1){
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        }
                    }
                    else
                    {
                        currentCharacter = "C";

                        if (gridScript.selectedCharacter == GameObject.Find("player1SlotC"))
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Left Player C Selected";
                            if (playerStatus.leftC.moved == false)
                                moveButton.SetActive(true);
                            if (playerStatus.leftC.attacked == false)
                                attackButton.SetActive(true);
                        }
                    }

                }


                if (hit.collider.name == "player2SlotA")
                {
                    // Melee Mode
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = "A2";
                        if(playerStatus.AisOK && playerStatus.turn == 0){
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's A player";
                        }
                        else if(!playerStatus.AisOK && playerStatus.turn == 0){
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        }
                    }
                    else
                    {
                        currentCharacter = "A2";

                        if (gridScript.selectedCharacter == GameObject.Find("player2SlotA"))
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Right Player A Selected";
                            if (playerStatus.rightA.moved == false)
                                moveButton.SetActive(true);
                            if (playerStatus.rightA.attacked == false)
                                attackButton.SetActive(true);

                        }
                    }
                }
                if (hit.collider.name == "player2SlotB")
                {
                    // Melee Mode
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = "B2";
                        if(playerStatus.BisOK && playerStatus.turn == 0){
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's B player";
                        }
                        else if(!playerStatus.BisOK && playerStatus.turn == 0){
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        }
                    }
                    else
                        currentCharacter = "B2";

                    if (gridScript.selectedCharacter == GameObject.Find("player2SlotB"))
                    {
                        infoBar.GetComponentInChildren<Text>().text = "Right Player B Selected";
                        if (playerStatus.rightB.moved == false)
                            moveButton.SetActive(true);
                        if (playerStatus.rightB.attacked == false)
                            attackButton.SetActive(true);

                    }
                }
                if (hit.collider.name == "player2SlotC")
                {
                    // Melee Mode
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = "C2";
                        if(playerStatus.CisOK && playerStatus.turn == 0){
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's C player";
                        }
                        else if(!playerStatus.CisOK && playerStatus.turn == 0){
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                        }
                    }
                    else
                    {
                        currentCharacter = "C2";

                        if (gridScript.selectedCharacter == GameObject.Find("player2SlotC"))
                        {
                            infoBar.GetComponentInChildren<Text>().text = "Right Player C Selected";
                            if (playerStatus.rightC.moved == false)
                                moveButton.SetActive(true);
                            if (playerStatus.rightC.attacked == false)
                                attackButton.SetActive(true);

                        }
                    }
                }
            }
            else // clicking away 
            {
               infoBar = GameObject.Find("InfoBar");
                if (moveButton.GetComponentInChildren<Text>().text == "Move" && meleeButton.GetComponentInChildren<Text>().text != "Confirm Melee")
                {
                    Debug.Log("clicking away");
                    moveButton.SetActive(false);
                    attackButton.SetActive(false);
                    fireButton.SetActive(false);
                    meleeButton.SetActive(false);
                    infoBar.GetComponentInChildren<Text>().text = "";
                    currentCharacter = "none";
                    meleeingCharacter = "none";
                }
            }

        }
    }
}

