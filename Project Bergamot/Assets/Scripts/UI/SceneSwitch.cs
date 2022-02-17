using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //SceneManager 
    //Switching scene from the menu to the game
    public void playUI_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backUI_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void startGame_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        Debug.Log("Pressed");
        Application.Quit();
    }
}
