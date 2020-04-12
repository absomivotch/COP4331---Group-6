using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    public GameObject attackButton, moveButton, meleButton, fireButton;

    public void attackButtonPressed()
    {
        if (attackButton.GetComponentInChildren<Text>().text == "Attack")
        {
            attackButton.GetComponentInChildren<Text>().text = "Exit Attack mode";
            moveButton.SetActive(false);
            meleButton.SetActive(true);
            meleButton.GetComponentInChildren<Text>().text = "Melee";
            fireButton.SetActive(true);
        }
        else{
            attackButton.GetComponentInChildren<Text>().text = "Attack";
            moveButton.SetActive(true);
            meleButton.SetActive(false);
            fireButton.SetActive(false);
        }
    }


}
