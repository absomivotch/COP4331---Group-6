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
    public static string lastLetter;
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

                lastLetter = hit.collider.name.Substring(hit.collider.name.Length - 1);
                if (hit.collider.name == "player1Slot" + lastLetter + "" && playerStatus.turn == 0)
                {

                    gridScript.selectedCharacter = GameObject.Find("player1Slot" + lastLetter);
                    currentCharacter = lastLetter;

                    if (gridScript.selectedCharacter == GameObject.Find("player1Slot" + lastLetter)) // double check with grid script
                    {
                        infoBar.GetComponentInChildren<Text>().text = "Left Player " + lastLetter + " Selected";
                        if (!playerStatus.leftA.moved | !playerStatus.leftB.moved | !playerStatus.leftC.moved)
                            moveButton.SetActive(true);
                        if (!playerStatus.leftA.attacked | !playerStatus.leftB.attacked | !playerStatus.leftC.attacked)
                            attackButton.SetActive(true);
                    }
                }
                else if (hit.collider.name == "player1Slot" + lastLetter + "" && playerStatus.turn == 1)
                {
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                           meleeingCharacter = lastLetter;
                                 if (playerStatus.AisOK | playerStatus.BisOK | playerStatus.CisOK)
                                   infoBar.GetComponentInChildren<Text>().text = "Choosing to melee left team's " + lastLetter + " player";
                                 else
                                   infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                    }
         
                        lastLetter = null;
                }
                
                else if (hit.collider.name == "player2Slot" + lastLetter + "" && playerStatus.turn == 1)
                {

                    gridScript.selectedCharacter = GameObject.Find("player2Slot" + lastLetter);
                    currentCharacter = lastLetter;

                    if (gridScript.selectedCharacter == GameObject.Find("player2Slot" + lastLetter)) // double check with grid script
                    {
                        infoBar.GetComponentInChildren<Text>().text = "Right Player " + lastLetter + " Selected";
                        if (!playerStatus.rightA.moved | !playerStatus.rightB.moved | !playerStatus.rightC.moved)
                            moveButton.SetActive(true);
                        if (!playerStatus.rightA.attacked | !playerStatus.rightB.attacked | !playerStatus.rightC.attacked)
                            attackButton.SetActive(true);
                    }
                }
                else if (hit.collider.name == "player2Slot" + lastLetter + "" && playerStatus.turn == 0)
                {
                    if (meleeButton.GetComponentInChildren<Text>().text == "Confirm Melee")
                    {
                        meleeingCharacter = lastLetter;
                        if (playerStatus.AisOK | playerStatus.BisOK | playerStatus.CisOK)
                            infoBar.GetComponentInChildren<Text>().text = "Choosing to melee right team's " + lastLetter + " player";
                        else
                            infoBar.GetComponentInChildren<Text>().text = "Player out of range";
                    }
           
              
                   
                }
                Debug.Log(lastLetter);

            }

            else
            {
                if (moveButton.GetComponentInChildren<Text>().text == "Move" && meleeButton.GetComponentInChildren<Text>().text != "Confirm Melee")
                {
                    Debug.Log("clicking away");
                    moveButton.SetActive(false);
                    attackButton.SetActive(false);
                    fireButton.SetActive(false);
                    meleeButton.SetActive(false);
                    infoBar.GetComponentInChildren<Text>().text = "";
                    attackButton.GetComponentInChildren<Text>().text = "Attack";
                    currentCharacter = "none";
                    meleeingCharacter = "none";

                }

            }
        }  
    }
}

      