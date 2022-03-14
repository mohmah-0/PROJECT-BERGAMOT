using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 3;
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
            FindObjectOfType<PodiumPlacements>().UpdateList(GetComponent<PlayerDetails>());


            GetComponent<PlayerUI>().RemoveLastImage();
            Destroy(GetComponent<PlayerUI>().borderItem);
            //FindObjectOfType<OutOfView>().cars.RemoveAt(GetComponent<PlayerDetails>().playerID);
            Debug.Log(transform.name);
            Destroy(transform.parent.gameObject);
        }
    }
}
