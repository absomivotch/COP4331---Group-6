using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int turn;
    void Start()
    {
        turn = 0;
        Debug.Log("turn 0");
        // Initalize the players' states.
        leftA.moved = false;
        leftA.attacked = false;
        leftA.isCaptured = false;
        leftA.hasBandana = false;

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
        rightA.hasBandana = false;

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
            Debug.Log("turn 1");
        }
        else
        {
            turn = 0;
            Debug.Log("turn 0");
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
