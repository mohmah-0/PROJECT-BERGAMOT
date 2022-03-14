using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PodiumPlacements : MonoBehaviour
{
    [SerializeField] List<int> players;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateList(PlayerDetails playerDetails)
    {
        players.Insert(0, playerDetails.playerID);
    }

    public void FinishGame()
    {
        Destroy(FindObjectOfType<AudioManager>());
        SceneManager.LoadScene("winnerPodium");
    }
}
