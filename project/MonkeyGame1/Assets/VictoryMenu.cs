using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public void VicPlayAgain()
    {
        SceneManager.LoadScene("Level0");
    }
    public void VicLoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void VicQuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
