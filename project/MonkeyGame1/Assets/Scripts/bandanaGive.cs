using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bandanaGive : MonoBehaviour
{

    private GameObject overallGrid;

    private GameObject tree1Tile1, tree1Tile2, tree1Tile3, tree1Tile4, tree1Tile5, tree1Tile6;
    private GameObject tree2Tile1, tree2Tile2, tree2Tile3, tree2Tile4, tree2Tile5, tree2Tile6;
    private GameObject moveButton;

    private GameObject bandana1, bandana2;

    
    void Start()
    {
        moveButton = GameObject.Find("Level0Map/Canvas/MoveButton");
        overallGrid = GameObject.Find("GridMap");
        bandana1 = GameObject.Find("Level0Map/Teams/player1Team/player1SlotA/Bandana(Clone)");
        bandana2 = GameObject.Find("Level0Map/Teams/player2Team/player2SlotA/Bandana(Clone)");

      
         tree1Tile1 = overallGrid.transform.Find("Tile_0_5").gameObject;
         tree1Tile2 = overallGrid.transform.Find("Tile_1_6").gameObject;
         tree1Tile3 = overallGrid.transform.Find("Tile_2_6").gameObject;
         tree1Tile4 = overallGrid.transform.Find("Tile_2_5").gameObject;
         tree1Tile5 = overallGrid.transform.Find("Tile_2_4").gameObject;
         tree1Tile6 = overallGrid.transform.Find("Tile_1_4").gameObject;

         tree2Tile1 = overallGrid.transform.Find("Tile_29_5").gameObject;
         tree2Tile2 = overallGrid.transform.Find("Tile_30_6").gameObject;
         tree2Tile3 = overallGrid.transform.Find("Tile_31_6").gameObject;
         tree2Tile4 = overallGrid.transform.Find("Tile_31_5").gameObject;
         tree2Tile5 = overallGrid.transform.Find("Tile_31_4").gameObject;
         tree2Tile6 = overallGrid.transform.Find("Tile_30_4").gameObject;
         
    }
    public void bandanaSearch()
    {
        if (bandana1.name == "player1SlotA")
            bandana1 = bandana1.transform.Find("Bandana(Clone)").gameObject;
        if (bandana2.name == "player2SlotA")
            bandana2 = bandana2.transform.Find("Bandana(Clone)").gameObject;

        if (moveButton.activeSelf == false)
        {
            if (Mathf.RoundToInt(tree1Tile1.transform.position.x) == Mathf.RoundToInt(bandana2.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer1");
            if (Mathf.RoundToInt(tree1Tile2.transform.position.x) == Mathf.RoundToInt(bandana2.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer1");
            if (Mathf.RoundToInt(tree1Tile3.transform.position.x) == Mathf.RoundToInt(bandana2.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer1");
            if (Mathf.RoundToInt(tree1Tile4.transform.position.x) == Mathf.RoundToInt(bandana2.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer1");
            if (Mathf.RoundToInt(tree1Tile5.transform.position.x) == Mathf.RoundToInt(bandana2.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer1");
            if (Mathf.RoundToInt(tree1Tile6.transform.position.x) == Mathf.RoundToInt(bandana2.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer1");


            if (Mathf.RoundToInt(tree2Tile1.transform.position.x) == Mathf.RoundToInt(bandana1.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer2");
            if (Mathf.RoundToInt(tree2Tile2.transform.position.x) == Mathf.RoundToInt(bandana1.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer2");
            if (Mathf.RoundToInt(tree2Tile3.transform.position.x) == Mathf.RoundToInt(bandana1.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer2");
            if (Mathf.RoundToInt(tree2Tile4.transform.position.x) == Mathf.RoundToInt(bandana1.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer2");
            if (Mathf.RoundToInt(tree2Tile5.transform.position.x) == Mathf.RoundToInt(bandana1.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer2");
            if (Mathf.RoundToInt(tree2Tile6.transform.position.x) == Mathf.RoundToInt(bandana1.transform.position.x))
                SceneManager.LoadScene("VictoryPlayer2");

        }
    }
    private void Update()
    {
 
    }
}
