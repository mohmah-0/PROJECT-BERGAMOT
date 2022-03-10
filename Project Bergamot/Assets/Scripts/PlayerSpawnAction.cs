using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSpawnAction : MonoBehaviour
{
    public Transform[] spawnPoints;

    

    public void OnPlayerJoined(PlayerInput playerInput)///kolla här
    {
        Debug.Log("Player " + playerInput.playerIndex + " joined the game!");
        Debug.Log("existerar: " + playerInput.transform.GetComponentInChildren<PlayerDetails>().name);
        playerInput.transform.GetComponentInChildren<PlayerDetails>().playerID = playerInput.playerIndex + 1;

        playerInput.transform.GetComponentInChildren<PlayerDetails>().startPos = spawnPoints[playerInput.playerIndex].position;
    }
}
