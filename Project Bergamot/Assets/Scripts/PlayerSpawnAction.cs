using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnAction : MonoBehaviour
{
    public static PlayerInputManager currentPlayerInputMananger, pastPlayerInputMananger;
    public Transform[] spawnPoints;


    private void Start()
    {
        gameObject.GetComponent<PlayerInputManager>().playerPrefab = pastPlayerInputMananger.playerPrefab;
    }


    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + " joined the game!");

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;

        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnPoints[playerInput.playerIndex].position;
    }
}
