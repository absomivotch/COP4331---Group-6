using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    public GameObject attackButton, moveButton, meleButton;

    public void attackButtonPressed()
    {
        attackButton = GameObject.Find("AttackButton");
        if (attackButton.GetComponentInChildren<Text>().text == "Attack")
        {
            attackButton.GetComponentInChildren<Text>().text = "Exit Attack mode";
            moveButton.SetActive(false);
            meleButton.SetActive(true);
            meleButton.GetComponentInChildren<Text>().text = "Melee";
        }
        else
        {
            attackButton.GetComponentInChildren<Text>().text = "Attack";
            moveButton.SetActive(true);
            meleButton.SetActive(false);
        }
    }


}
