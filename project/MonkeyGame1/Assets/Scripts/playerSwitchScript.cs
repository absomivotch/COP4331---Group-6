using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwitchScript : MonoBehaviour
{
    public GameObject[] characters;
    public int activeChar = 0;

    void Start()
    {
        characters[0].GetComponent<playerMovement>().enabled = true;
        characters[1].GetComponent<playerMovement>().enabled = false;
        characters[2].GetComponent<playerMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("tab"))
        {
            characters[activeChar].GetComponent<playerMovement>().enabled = false;
            if (activeChar + 1 == 3)
                activeChar = -1;
            characters[++activeChar].GetComponent<playerMovement>().enabled = true;
        }
    }
}
