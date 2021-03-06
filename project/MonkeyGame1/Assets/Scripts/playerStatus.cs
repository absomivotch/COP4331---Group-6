﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStatus : MonoBehaviour
{
    public struct playerState
    {
        public bool moved;
        public bool attacked;
        public bool isCaptured;
        public bool hasBandana;
    }

    
    public playerState leftA, leftB, leftC, rightA, rightB, rightC;
    public bool AisOK = false, BisOK = false, CisOK = false, meleeMode = false;
    public int turn;
    public GameObject bandannaLeft, bandannaRight;
    void Start()
    {
        GameObject.Find("InfoBar").GetComponentInChildren<Text>().text = "Left's Turn, Double click to select characters";
        turn = 0;
        bandannaLeft =  GameObject.Find("Level0Map/Teams/player1Team/player1SlotA/Bandana(Clone)");
        bandannaRight =  GameObject.Find("Level0Map/Teams/player2Team/player2SlotA/Bandana(Clone)");
        // Initalize the players' states.
        leftA.moved = false;
        leftA.attacked = false;
        leftA.isCaptured = false;
        leftA.hasBandana = true;

        leftB.moved = false;
        leftB.attacked = false;
        leftB.isCaptured = false;
        leftB.hasBandana = false;

        leftC.moved = false;
        leftC.attacked = false;
        leftC.isCaptured = false;
        leftC.hasBandana = false;

        rightA.moved = false;
        rightA.attacked = false;
        rightA.isCaptured = false;
        rightA.hasBandana = true;

        rightB.moved = false;
        rightB.attacked = false;
        rightB.isCaptured = false;
        rightB.hasBandana = false;

        rightC.moved = false;
        rightC.attacked = false;
        rightC.isCaptured = false;
        rightC.hasBandana = false;

    }
   
    public void nextTurn(){
        if(turn == 0){
            turn = 1;
            GameObject.Find("InfoBar").GetComponentInChildren<Text>().text = "Right's Turn";
        }
        else
        {
            turn = 0;
           GameObject.Find("InfoBar").GetComponentInChildren<Text>().text = "Left's Turn";
        }
        leftA.moved = false;
        leftA.attacked = false;

        leftB.moved = false;
        leftB.attacked = false;

        leftA.moved = false;
        leftA.attacked = false;

        leftC.moved = false;
        leftC.attacked = false;

        rightA.moved = false;
        rightA.attacked = false;

        rightB.moved = false;
        rightB.attacked = false;

        rightC.moved = false;
        rightC.attacked = false;

    }


}
