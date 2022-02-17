using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    int carType = 0;

    // Start is called before the first frame update
    void Start()
    {
        Marked.playerObject.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveRight()
    {
        if (carType < 4)//refferens till marked
        {
            carType++;
        }

        for(int i = 0; i < Marked.playerObject.Count; i++)
        {
            if (Marked.playerObject[i] == gameObject)
            {
                Debug.Log("tatatatata" + i);
            }
        }
    }

    public void moveLeft(InputAction.CallbackContext action)
    {
        if (carType >= 0)//refferens till marked
        {
            carType--;
        }
    }

    public void moveDown(InputAction.CallbackContext action)
    {

    }

    public void moveUp(InputAction.CallbackContext action)
    {

    }
}
