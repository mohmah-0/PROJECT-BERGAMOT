using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Marked : MonoBehaviour
{
    public static GameObject camera;
    public static List<GameObject> playerObject = new List<GameObject>();//try swiching to the players script it self
    public static List<GameObject> buttons = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        buttons.AddRange(GameObject.FindGameObjectsWithTag("Button"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    //PlayerColour is temporarely a string and should be later on changed, (players should understand when same button is marked by multiple players)
    public static void markButton(int whichButton, string playerColour)
    {
        buttons[whichButton].transform.GetChild(0).GetComponent<Text>().text = playerColour;
    }

    public static void pressButton(int whichButton, GameObject whichPlayer)//try swiching player gameobject to the players script it self
    {
        if(whichButton == buttons.Count - 1)//the last button on the canvas list which is "start" button
        {
            //somehow transfer the players controll together with thier chosen cars to the next scene and go to next scene
            Debug.Log("pressed start");
            for(int i = 0; i < playerObject.Count; i++)
            {
                SceneSwitch.DontDestroyOnLoad(playerObject[i]);
                playerObject[i].GetComponent<PlayerScript>().changeScene();
            }
            SceneManager.LoadScene(1);

        }
        else
        {
            //whateer should happen when player selected the car on button that is on the index "whichButton" - 1 on the button list
            Debug.Log("pressed car nr: " + whichButton);
            whichPlayer.GetComponent<PlayerScript>().select = whichButton;
        }
    }

}
