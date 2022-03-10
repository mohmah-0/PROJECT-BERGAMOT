using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    int selectedButton = 0, previouslySelectedButton = -1;
    public int playerColor;
    bool previousIsTopRow = true, isTopRow = true;
    List<GameObject> currentButtonRow;//använd bara för kolla storlek(osäker om annat funkar)
    public GameObject playerCar;
    public CarMovment playerCarMovment;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerColor = GetComponent<PlayerInput>().playerIndex;
        Marked.playerObject.Add(gameObject);
        currentButtonRow = Marked.buttonsTopRow;
        Marked.markButton(selectedButton, previouslySelectedButton, previousIsTopRow, true, playerColor);
        playerCar = Marked.changeCar(selectedButton, gameObject, playerCar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveRight(InputAction.CallbackContext action)
    {
        if(action.performed)
        {
            if (selectedButton < currentButtonRow.Count - 1)
            {
                previouslySelectedButton = selectedButton;
                selectedButton++;

                previousIsTopRow = isTopRow;
                isTopRow = currentButtonRow == Marked.buttonsTopRow;



                Marked.markButton(selectedButton, previouslySelectedButton, previousIsTopRow, isTopRow, playerColor);
                
                if (isTopRow)//-------------------------------------------Måste hitta ett sätt att hålla kvar hostens senaste sekectade knapp och dess markering innan han selectar knapp i nedre raden. Annars vet vi inte vilken bil hosten valde.  Testa skicka in topRow i changedCar metoden nedan, jag tror vi kan spara den i Marker scripten då vi endå har en enda host. Just nu funkar allt bra förutom att knappen markeras alldrig tror jag(ganska säker måste gå toa).
                {
                    playerCar = Marked.changeCar(selectedButton, gameObject, playerCar);
                }
            }

        }
    }

    public void moveLeft(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            if (selectedButton > 0)//button 3 and 4 is in the bottom row
            {
                previouslySelectedButton = selectedButton;
                selectedButton--;

                previousIsTopRow = isTopRow;
                isTopRow = currentButtonRow == Marked.buttonsTopRow;

                Marked.markButton(selectedButton, previouslySelectedButton, previousIsTopRow, isTopRow, playerColor);
                if (isTopRow)
                {
                    playerCar = Marked.changeCar(selectedButton, gameObject, playerCar);
                }
            }

        }
    }

    public void moveDown(InputAction.CallbackContext action)
    {
        if(playerColor == 0)//endast förstaspelaren får selecta knapparna under.
        {
            if (action.performed)
            {
                if (currentButtonRow == Marked.buttonsTopRow)
                {
                    currentButtonRow = Marked.buttonsBottomRow;

                    previousIsTopRow = isTopRow;
                    isTopRow = currentButtonRow == Marked.buttonsTopRow;

                    previouslySelectedButton = selectedButton;
                    selectedButton = 0;

                    Marked.markButton(selectedButton, previouslySelectedButton, true, false, playerColor);
                }
            }
        }
    }

    public void moveUp(InputAction.CallbackContext action)
    {
        if (playerColor == 0)//endast förstaspelaren får selecta knapparna under.
        {
            if (action.performed)
            {
                if (currentButtonRow == Marked.buttonsBottomRow)
                {
                    currentButtonRow = Marked.buttonsTopRow;

                    previousIsTopRow = isTopRow;
                    isTopRow = currentButtonRow == Marked.buttonsTopRow;

                    previouslySelectedButton = selectedButton;
                    selectedButton = 0;

                    Marked.markButton(selectedButton, previouslySelectedButton, false, true, playerColor);//kanske ersätt true och false med isTopRow och den andra
                    playerCar = Marked.changeCar(selectedButton, gameObject, playerCar);
                }
            }
        }
    }

    public void pressedX(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            if(isTopRow == false)
            {
                Marked.pressButton(selectedButton);
            }
        }
    }


    public void carDriveForward(InputAction.CallbackContext action)//only used by Player controll scheme
    {
        playerCarMovment.accelerate(action);
    }
    public void carDriveBack(InputAction.CallbackContext action)//only used by Player controll scheme
    {
        playerCarMovment.decelerate(action);
    }
    public void carSteering(InputAction.CallbackContext action)//only used by Player controll scheme
    {
        playerCarMovment.steer(action);
    }
    public void carPressedX(InputAction.CallbackContext action)//only used by Player controll scheme
    {
        playerCarMovment.drift(action);
    }


    public static void resetAllPlayers()//dont use this unless you want to do car selection all over again.(should be used from marked)
    {
        //resett everything in all PlayerScripts and not Marked
    }
}
