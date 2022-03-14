using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public void GoMainMenu()
    {
        Marked.resetAllMarkers();
        PlayerScript.resetAllPlayers();
        foreach (Sound s in FindObjectOfType<AudioManager>().sounds)
        {
            s.source.Stop();
        }
        Destroy(FindObjectOfType<AudioManager>());

        GameObject[] objectsInScene = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objectsInScene)
        {
            if(obj.layer == 9)
            {
                Destroy(obj);
            }
        }
        SceneManager.LoadScene("StartMenu");
    }
}
