using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSpawnAction : MonoBehaviour
{
    public Transform[] spawnPoints;

    void Start()//switching controlls from ui controlls to car controll for the recently transfered cars
    {
        GameObject[] tempAllPlayers = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < tempAllPlayers.Length; i++)
        {
            Debug.Log("playerobject: " + tempAllPlayers[i].gameObject.name + "");
            CarMovment tempScript = tempAllPlayers[i].GetComponent<CarMovment>();
            OnPlayerJoined(tempScript.setupCar());
            tempScript.readyForRace = true;
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)///positioning the car
    {

        playerInput.SwitchCurrentActionMap("Player controll");
        
        playerInput.transform.GetComponentInChildren<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.transform.position = spawnPoints[playerInput.playerIndex].position;
    }
}
