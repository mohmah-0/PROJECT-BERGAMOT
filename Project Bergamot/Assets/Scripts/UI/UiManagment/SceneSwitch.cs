using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingCanvas;
    public Animator transitionAnimator;

    public void backUI_BTN()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void startGame_BTN()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    void FadeToLevel(int mapIndex)
    {   
        StartCoroutine(delaySec(mapIndex));
       // SceneManager.LoadSceneAsync(sceneName);
    }

    IEnumerator delaySec(int mapIndex)
    {
        transitionAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(.75f);
        SceneManager.LoadSceneAsync(mapIndex);
    }
}
