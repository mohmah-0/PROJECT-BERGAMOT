using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerCount : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 20f;

    [SerializeField] Text timerUI;
    mapManager MapManager;

    void Start()
    {
        currentTime = startingTime;
        MapManager = GameObject.Find("MapManager").GetComponent<mapManager>();
    }

    void Update()
    {
        //Fix the smoothnest of the transition
        if(currentTime >= 0)
        {
            currentTime -= 1 * Time.deltaTime;
            timerUI.text = currentTime.ToString("0");    
            if(currentTime <= 5)
            {
                timerUI.color = Color.red;
            }
        }
        else
        {
            MapManager.RandomizeMap();
            this.GetComponent<timerCount>().enabled = false;
        }

    }
}
