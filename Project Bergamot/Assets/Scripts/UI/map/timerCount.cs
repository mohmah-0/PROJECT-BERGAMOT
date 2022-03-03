using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerCount : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] Text timerUI;

    void Start()
    {
        currentTime = startingTime;    
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
            //Randomize the selection map 
            Debug.Log("Reached the end: " + currentTime);
            //currentTime = 0;
        }
    }
}
