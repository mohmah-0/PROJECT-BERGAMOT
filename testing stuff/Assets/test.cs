using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = GetComponent<PlayerInput>().playerIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pressA(InputAction.CallbackContext test)//säger namn 1
    {
        if (test.performed)
        {
            Debug.Log(name + " pressed");
        }
    }

    public void pressX(InputAction.CallbackContext test)//säger namn 2
    {
        if (test.performed)
        {
            Debug.Log(name + " pressed");
        }
    }

    public void pressY(InputAction.CallbackContext test)//bytar knapp 1
    {
        if (test.performed)
        {
            Debug.Log("byter knapp");
            GetComponent<PlayerInput>().SwitchCurrentActionMap("test2");
        }
    }
    public void pressY2(InputAction.CallbackContext test)//bytar knapp 2
    {
        if (test.performed)
        {
            Debug.Log("byter knapp");
            GetComponent<PlayerInput>().SwitchCurrentActionMap("test1");
        }
    }


    public void pressB(InputAction.CallbackContext test)//Disebla enebla
    {
        if (test.performed)
        {
            gameObject.GetComponent<PlayerInput>().enabled = false;
            gameObject.GetComponent<PlayerInput>().enabled = true;
            Debug.Log("done");
        }
    }

}
