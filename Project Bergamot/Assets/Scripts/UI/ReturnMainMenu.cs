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
        SceneManager.LoadScene("StartMenu");
    }
}
