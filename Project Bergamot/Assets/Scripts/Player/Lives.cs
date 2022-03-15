using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int lives = 3;
    public bool hasRespawned = true;
    public void OutOfView()
    {
        lives--;
        FindObjectOfType<CrossCheckHandler>().onOutOfBounds(gameObject);
        if (lives > 0 && hasRespawned)
        {
            GetComponent<PlayerUI>().RemoveLastImage();
            StartCoroutine(GetComponent<Respawn>().CarRespawn());
        }
        if (lives <= 0)
        {
            int playersOut = FindObjectOfType<OutOfView>().playersOut;
            FindObjectOfType<PodiumPlacements>().UpdateList(GetComponent<PlayerDetails>());

            switch(playersOut)
            {
                case 0:
                    FindObjectOfType<OutOfView>().playersOut++;
                    GetComponent<PlayerDetails>().placement = FindObjectOfType<OutOfView>().cars.Count-1;
                    break;
                case 1:
                    FindObjectOfType<OutOfView>().playersOut++;
                    GetComponent<PlayerDetails>().placement = FindObjectOfType<OutOfView>().cars.Count-1;
                    break;
                case 2:
                    FindObjectOfType<OutOfView>().playersOut++;
                    GetComponent<PlayerDetails>().placement = FindObjectOfType<OutOfView>().cars.Count-1;
                    break;
                default:
                    FindObjectOfType<CrossCheckHandler>().getLeadCar().GetComponent<PlayerDetails>().placement = 0;
                    break;
            }


            GetComponent<PlayerUI>().RemoveLastImage();
            Destroy(GetComponent<PlayerUI>().borderItem);
            FindObjectOfType<OutOfView>().cars.Remove(transform.GetChild(0).GetChild(0).gameObject);
            transform.parent.gameObject.GetComponent<PlayerScript>().enableControlls = false;
            transform.gameObject.SetActive(false);
        }
    }
}
