using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamSwitchScript : MonoBehaviour
{
    public GameObject player1Team = GameObject.Find("player1Team");
    public GameObject player2Team = GameObject.Find("player2Team");

    void Start()
    {
        player1Team.SetActive(true);
        player2Team.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("q"))
        {
            player1Team.SetActive(true);
            player2Team.SetActive(false);
        }

        if (Input.GetKey("e"))
        {
            player1Team.SetActive(false);
            player2Team.SetActive(true);
        }
    }
}
