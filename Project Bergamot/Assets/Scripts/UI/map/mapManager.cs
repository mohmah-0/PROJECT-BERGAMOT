using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mapManager : MonoBehaviour
{    
    private string mapName;
    public GameObject loadingScreen;
    public Slider loadingSlider;

    public void mapSelected(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }

    public void loadLevel(string name)
    {
        StartCoroutine(LoadAsync(name));
    }

    IEnumerator LoadAsync(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        loadingScreen.SetActive(true);
        while(!asyncOperation.isDone)
        {
           float loadingProgress = Mathf.Clamp01(asyncOperation.progress / .9f);
           loadingSlider.value = loadingProgress;
           yield return null;          
        }
    }
}
