using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnAction : MonoBehaviour
{
    public Transform[] spawnPoints;
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + " joined the game!");

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;

        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnPoints[playerInput.playerIndex].position;
    }
}
