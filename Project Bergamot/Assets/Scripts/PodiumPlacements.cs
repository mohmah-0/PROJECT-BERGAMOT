using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PodiumPlacements : MonoBehaviour
{
    public List<int> players;
    public List<int> carType;
    float endtime = 1;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateList(PlayerDetails playerDetails)
    {
        players.Insert(0, playerDetails.playerID);
        carType.Insert(0, playerDetails.carType);
    }

    public void FinishGame()
    {
        Time.timeScale = 0.5f;
        Debug.Log("Hey");
        endtime -= Time.deltaTime;
        if (endtime < 0)
        {
            Time.timeScale = 1;
            GameObject[] tempPlayers = GameObject.FindGameObjectsWithTag("Player controller");
            foreach (GameObject car in tempPlayers)
            {
                //Debug.Log(car.transform.parent.parent.parent.gameObject.name);
                car.transform.GetChild(0).gameObject.SetActive(true);
            }
            Destroy(FindObjectOfType<AudioManager>());
            SceneManager.LoadScene("winnerPodium");
        }
    }
}
