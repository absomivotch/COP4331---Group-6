using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerSelect : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;

    public GameObject playerA, playerB, playerC, moveButton, attackButton, meleButton, fireButton;
    public static string currentCharacter = "none";



    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject infoBar = GameObject.Find("InfoBar");
            playerStatus playerStatus = GameObject.Find("GridMap").GetComponent<playerStatus>();
            
            // Click the character you want to play as, esnure that you're not already in movement mode.
            if(Physics.Raycast(ray, out hit, rayLength, layermask))
            {
               if(hit.collider.name == "player1SlotA")
               {
                    currentCharacter = "A";
                    if(playerStatus.leftA.moved == false)
                        moveButton.SetActive(true);
                    if(playerStatus.leftA.attacked == false)
                        attackButton.SetActive(true);
               }
               else if(hit.collider.name == "player1SlotB")
               {
                    currentCharacter = "B";
                   if(playerStatus.leftB.moved == false)
                        moveButton.SetActive(true);
                    if(playerStatus.leftB.attacked == false)
                        attackButton.SetActive(true);

               }
               else if(hit.collider.name == "player1SlotC")
               {
                   currentCharacter = "C";
                   if(playerStatus.leftC.moved == false)
                        moveButton.SetActive(true);
                    if(playerStatus.leftC.attacked == false)
                        attackButton.SetActive(true);
               }
               
            }

            else // clicking away
            {
                    if(moveButton.GetComponentInChildren<Text>().text == "Move"){
                         moveButton.SetActive(false);
                         attackButton.SetActive(false);
                         fireButton.SetActive(false);
                         meleButton.SetActive(false);
                         infoBar.GetComponentInChildren<Text>().text = "";
                         currentCharacter = "none";
                    }
                   
            }
        }
    }
}
