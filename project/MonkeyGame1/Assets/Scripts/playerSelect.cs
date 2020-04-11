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
                    }
                    else
                    {
                        currentCharacter = "A";

                        if (gridScript.selectedCharacter == GameObject.Find("player1SlotA")) // double check with grid script
                        {
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
                    }
                    else
                    {
                        currentCharacter = "B";

                        if (gridScript.selectedCharacter == GameObject.Find("player1SlotB"))
                        {
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
                    }
                    else
                    {
                        currentCharacter = "C";

                        if (gridScript.selectedCharacter == GameObject.Find("player1SlotC"))
                        {
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
                    }
                    else
                    {
                        currentCharacter = "A2";

                        if (gridScript.selectedCharacter == GameObject.Find("player2SlotA"))
                        {
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
                    }
                    else
                        currentCharacter = "B2";

                    if (gridScript.selectedCharacter == GameObject.Find("player2SlotB"))
                    {
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
                    }
                    else
                    {
                        currentCharacter = "C2";

                        if (gridScript.selectedCharacter == GameObject.Find("player2SlotC"))
                        {
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
                if (moveButton.GetComponentInChildren<Text>().text == "Move")// && meleeButton.GetComponentInChildren<Text>().text != "Confirm Melee")
                {
                    moveButton.SetActive(false);
                    attackButton.SetActive(false);
                    fireButton.SetActive(false);
                    meleeButton.SetActive(false);
                    infoBar.GetComponentInChildren<Text>().text = "";
                    currentCharacter = "none";
                }
            }

        }
    }
}

