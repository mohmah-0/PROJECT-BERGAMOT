using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PodiumPlacements : MonoBehaviour
{
    [SerializeField] List<int> players;
    float endtime = 1;
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
        Time.timeScale = 0.5f;

        endtime -= Time.deltaTime;
        if (endtime < 0)
        {
            Time.timeScale = 1;
            Destroy(FindObjectOfType<AudioManager>());
            SceneManager.LoadScene("winnerPodium");
        }
    }
}
