using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSpawnAction : MonoBehaviour
{
    public Transform[] spawnPoints;

    void Start()//Setting up the recently transfered cars
    {
        GameObject[] tempPlayer = GameObject.FindGameObjectsWithTag("Player controller");

        for(int i = 0; i < tempPlayer.Length; i++)
        {
            GameObject tempPlayerCar = tempPlayer[i].transform.GetChild(0).gameObject;
            PlayerScript tempScript = tempPlayer[i].GetComponent<PlayerScript>();

            spawningCar(tempPlayerCar, tempPlayer[i].GetComponent<PlayerInput>().playerIndex + 1);
            setupPlayerControll(tempPlayer[i], tempPlayerCar.GetComponent<CarMovment>());
        }
    }


    void spawningCar(GameObject player, int playerNumber)
    {
        player.SetActive(true);
        player.transform.position = spawnPoints[playerNumber].position;
    }

    void setupPlayerControll(GameObject player, CarMovment car)
    {
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player controll");
        PlayerScript tempPlayerScript = player.GetComponent<PlayerScript>();
        tempPlayerScript.playerCarMovment = car;
        tempPlayerScript.enableControlls = true;
    }
}
