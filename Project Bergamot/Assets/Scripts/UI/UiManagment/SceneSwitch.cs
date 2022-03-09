using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingCanvas;

    public void backUI_BTN()
    {
       
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void startGame_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openSetting()
    {    
        mainCanvas.SetActive(false);
        settingCanvas.SetActive(true); 
    }

    public void settingReturn()
    {
        settingCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
