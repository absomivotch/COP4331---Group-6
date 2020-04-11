using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    public GameObject attackButton, moveButton, meleButton, fireButton;

   public void attackButtonPressed(){
       attackButton.SetActive(false);
       moveButton.SetActive(false);
       meleButton.SetActive(true);
       fireButton.SetActive(true);
   }

   
}
