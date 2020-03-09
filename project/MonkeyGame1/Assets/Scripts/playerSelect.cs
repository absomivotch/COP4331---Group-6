using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerSelect : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;

     public GameObject playerA, playerB, playerC;

     void Start()
    {
        playerA.GetComponent<playerMovement>().enabled = false;
        playerB.GetComponent<playerMovement>().enabled = false;
        playerC.GetComponent<playerMovement>().enabled = false;
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength, layermask)){
               Debug.Log(hit.collider.name); 
               if(hit.collider.name == "player1SlotA"){
                    playerA.GetComponent<playerMovement>().enabled = true;
                    playerB.GetComponent<playerMovement>().enabled = false;
                    playerC.GetComponent<playerMovement>().enabled = false;
               }
               else if(hit.collider.name == "player1SlotB"){
                    playerA.GetComponent<playerMovement>().enabled = false;
                    playerB.GetComponent<playerMovement>().enabled = true;
                    playerC.GetComponent<playerMovement>().enabled = false;
               }
               else if(hit.collider.name == "player1SlotC"){
                    playerA.GetComponent<playerMovement>().enabled = false;
                    playerB.GetComponent<playerMovement>().enabled = false;
                    playerC.GetComponent<playerMovement>().enabled = true;
               }
            }
        }
    }
}
