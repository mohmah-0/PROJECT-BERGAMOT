using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;


    public void OnPlayerJoined(PlayerInput playerInput)
    {
        resetToSpawnPosition(playerInput);
        CrossChecking.applyCrossChecking(playerInput);//also enables camera to work on it

    }


    void resetToSpawnPosition(PlayerInput playerInput)
    {

        Debug.Log("Player " + playerInput.playerIndex + " joined the game!");

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;

        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnPoints[playerInput.playerIndex].position;
    }
}
