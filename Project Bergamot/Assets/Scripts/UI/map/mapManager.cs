using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mapManager : MonoBehaviour
{    
    [SerializeField] private string mapName;

    public void mapSelected(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }
}
