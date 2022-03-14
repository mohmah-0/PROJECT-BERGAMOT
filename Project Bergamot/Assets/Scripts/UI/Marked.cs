using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Marked : MonoBehaviour//player 1 = röd, player 2 = blå, player 3 = gul, player 4 =grön
{
    public static List<GameObject> playerObject;//try swiching to the players script it self or the playerColor(playerid)
    public static List<GameObject> buttonsTopRow;//fixa så den blir GameObject[][] buttons
    public static List<GameObject> buttonsBottomRow;
    public static List<int>[] topRowButtonMarkings, bottomRowButtonMarkings;
    public static Color[] playerColors = { Color.red, Color.blue, Color.yellow, Color.green, new Color(0, 0, 0, 0) };
    public static GameObject[] carTypes;
    static int hostTopRowSelectedButton;

    // Start is called before the first frame update
    void Awake()
    {
        start();
        carTypes = new GameObject[4]{ Resources.Load("RegularRaceCar") as GameObject, Resources.Load("CoolerRaceCar") as GameObject, Resources.Load("RegularRaceCar") as GameObject, Resources.Load("RegularRaceCar") as GameObject };
        settingUpButtons();
    }
    private void start()//dfmkaösdjö
    {

        playerObject = new List<GameObject>();
        buttonsTopRow = new List<GameObject>();
        buttonsBottomRow = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void markButton(int whichButton, int previousButton, bool previousIsTopRow, bool isTopRow, int playerColor)
    {

        if (isTopRow)
        {
            
            if(previousButton >= 0)
            {
                if (previousIsTopRow == false)//goes up from bottom row buttons
                {
                    removeMark(previousButton, previousIsTopRow, playerColor);
                    removeMark(hostTopRowSelectedButton, true, playerColor);
                }
                else
                {
                    removeMark(previousButton, previousIsTopRow, playerColor);
                }
                topRowButtonMarkings[whichButton].Add(playerColor);
                uppdateMark(whichButton, isTopRow);
            }
            else
            {
                topRowButtonMarkings[whichButton].Add(playerColor);
                uppdateMark(whichButton, isTopRow);
            }
        }
        else//if bottom row now
        {
            
            if (previousButton >= 0)
            {
                if(previousIsTopRow == true)//goes down from top Row Buttons
                {
                    hostTopRowSelectedButton = previousButton;
                }
                else
                {
                    removeMark(previousButton, previousIsTopRow, playerColor);
                }
                bottomRowButtonMarkings[whichButton].Add(playerColor);
                uppdateMark(whichButton, isTopRow);
            }
            else
            {
                bottomRowButtonMarkings[whichButton].Add(playerColor);
                uppdateMark(whichButton, isTopRow);
            }
        }
    }


    public static void removeMark(int whichButton, bool isTopRow, int playerColor)
    {
        if (isTopRow)
        {
            topRowButtonMarkings[whichButton].Remove(playerColor);
            uppdateMark(whichButton, isTopRow);
        }
        else
        {
            //if bottom row
            bottomRowButtonMarkings[whichButton].Remove(playerColor);
            uppdateMark(whichButton, isTopRow);
        }
    }

    public static void uppdateMark(int whichButton, bool isTopRow)
    {
        if (isTopRow)
        {
            //removing all markers
            Debug.Log("knapp: " + whichButton);
            Debug.Log(buttonsTopRow[whichButton].name);
            GameObject tempPanel = buttonsTopRow[whichButton].transform.parent.gameObject;
            tempPanel.GetComponent<Image>().color = playerColors[playerColors.Length - 1];

            for (int i = 0; i < 3; i++)//4 är antalet paneler alltså maximala antalet spelare
            {
                tempPanel = tempPanel.transform.parent.gameObject;
                tempPanel.GetComponent<Image>().color = playerColors[playerColors.Length - 1];
            }

            //reaplying the new markers
            for (int u = 0; u < topRowButtonMarkings[whichButton].Count; u++)//loops for amount of players marking this button
            {

                GameObject tempPanel2 = buttonsTopRow[whichButton].transform.parent.gameObject;
                for (int i = 0; i < u; i++)
                {
                    tempPanel2 = tempPanel2.transform.parent.gameObject;
                }

                tempPanel2.GetComponent<Image>().color = playerColors[topRowButtonMarkings[whichButton][u]];
            }
        }
        else
        {
            //if bottom row
            buttonsBottomRow[whichButton].transform.parent.gameObject.GetComponent<Image>().color = playerColors[playerColors.Length - 1];

            if (bottomRowButtonMarkings[whichButton].Count >= 1)//ifall vi i frammtiden vill ha fler hosts än en, annars == 1
            {
                buttonsBottomRow[whichButton].transform.parent.gameObject.GetComponent<Image>().color = playerColors[bottomRowButtonMarkings[whichButton][0]];
            }

        }
    }

    public static void pressButton(int whichButton)//endast host bör ha åtkomst
    {
        if(whichButton == 0)//pressed on start
        {
            disablingControlls();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(whichButton == 1)//pressed on back
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }//add else if in case we get more buttons

    }

    void settingUpButtons()
    {
        buttonsTopRow.AddRange(GameObject.FindGameObjectsWithTag("ButtonTopRow"));
        buttonsBottomRow.AddRange(GameObject.FindGameObjectsWithTag("ButtonBottomRow"));
        topRowButtonMarkings = new List<int>[buttonsTopRow.Count];
        bottomRowButtonMarkings = new List<int>[buttonsBottomRow.Count];


        for (int i = 0; i < topRowButtonMarkings.Length; i++)
        {
            topRowButtonMarkings[i] = new List<int>();
        }

        for (int i = 0; i < bottomRowButtonMarkings.Length; i++)
        {
            bottomRowButtonMarkings[i] = new List<int>();
        }
    }

    static void disablingControlls()
    {
        for(int i = 0; i < playerObject.Count; i++)
        {
            PlayerScript tempScript = playerObject[i].GetComponent<PlayerScript>();
            tempScript.enableControlls = false;
        }
    }

    public static GameObject changeCar(int whichButton, GameObject whichPlayer, GameObject playerCurrentCar)
    {

        if (playerCurrentCar == null)
        {
            GameObject tempPlayerCar = Instantiate<GameObject>(carTypes[whichButton], whichPlayer.transform);
            tempPlayerCar.name = tempPlayerCar.name + whichPlayer.GetComponent<PlayerInput>().playerIndex;//might remove----
            tempPlayerCar.SetActive(false);
            return tempPlayerCar;
        }
        else if (playerCurrentCar.name.StartsWith(carTypes[whichButton].name))
        {
            return playerCurrentCar;
        }
        else
        {
            Destroy(whichPlayer.transform.Find(playerCurrentCar.name).gameObject);
            GameObject tempPlayerCar = Instantiate<GameObject>(carTypes[whichButton], whichPlayer.transform);
            tempPlayerCar.name = tempPlayerCar.name + whichPlayer.GetComponent<PlayerInput>().playerIndex;//might remove-----
            tempPlayerCar.SetActive(false);
            return tempPlayerCar;
        }
    }


    public static void resetAllMarkers()//dont use this unless you want to do car selection all ove again.
    {
        //resett everything as if we just came from star menu. glöm inte ändra scheme och sätta playercarmovment till noll. håll koll på både den och spelarnas script version av reset
        //PlayerScript.resetAllPlayers();...

    }


}
