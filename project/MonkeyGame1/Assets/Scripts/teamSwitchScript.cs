using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamSwitchScript : MonoBehaviour
{
    public GameObject player1Team = GameObject.Find("player1Team");
    public GameObject player2Team = GameObject.Find("player2Team");


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("q"))
        {
            player1Team.GetComponent<playerMovement>().enabled = true;
            player2Team.GetComponent<playerMovement>().enabled = false;
        }

        if (Input.GetKey("e"))
        {
            player1Team.GetComponent<playerMovement>().enabled = false;
            player2Team.GetComponent<playerMovement>().enabled = true;
        }
    }
}
