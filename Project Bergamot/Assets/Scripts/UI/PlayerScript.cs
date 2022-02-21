using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    int carType = 0;
    public int select = 0;

    // Start is called before the first frame update
    void Start()
    {
        Marked.playerObject.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveRight(InputAction.CallbackContext action)
    {
        if(action.performed)
        {
            if (carType < Marked.buttons.Count - 1)
            {
                carType++;

                for (int i = 0; i < Marked.playerObject.Count; i++)
                {
                    if (Marked.playerObject[i] == gameObject)
                    {
                        Marked.markButton(carType, "här: " + carType);
                    }
                }
            }

        }
    }

    public void moveLeft(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            if (carType > 0)
            {
                carType--;


                for (int i = 0; i < Marked.playerObject.Count; i++)
                {
                    if (Marked.playerObject[i] == gameObject)
                    {

                        Marked.markButton(carType, "här: " + carType);
                    }
                }
            }

        }
    }

    public void moveDown(InputAction.CallbackContext action)
    {

    }

    public void moveUp(InputAction.CallbackContext action)
    {

    }

    public void pressedX(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            Marked.pressButton(carType, gameObject);
        }
    }


    public void changeScene()
    {
        gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("test");
    }

    public void test(InputAction.CallbackContext action)
    {
        Debug.Log("im still here: " + carType);
    }
}
