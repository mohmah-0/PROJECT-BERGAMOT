using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager loadingManager;
    public GameObject loadingScreen;
    public enum sceneIndex
    {
        Test = 0,
        Main = 1,
        Select = 2,
        Map = 3,
        Game = 4
    }

    private void Awake()
    {
        loadingManager = this;
        SceneManager.LoadSceneAsync((int)sceneIndex.Main, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.UnloadSceneAsync((int)sceneIndex.Main);
        SceneManager.LoadSceneAsync((int)sceneIndex.Game,LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync((int)sceneIndex.Game);
    }
}
