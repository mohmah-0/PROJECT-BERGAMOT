using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public void GoMainMenu()
    {
        Destroy(FindObjectOfType<AudioManager>());
        SceneManager.LoadScene("StartMenu");
    }
}
