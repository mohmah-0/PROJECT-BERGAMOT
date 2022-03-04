using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 3;
    public bool hasRespawned = true;
    public void OutOfView()
    {
        if (lives > 0 && hasRespawned)
        {
            lives--;
            GetComponent<PlayerUI>().RemoveLastImage();
            hasRespawned = false;
            StartCoroutine(GetComponent<Respawn>().CarRespawn());
        }
        else if (lives <= 0)
            GameObject.FindGameObjectWithTag("CrossChecking").GetComponent<CrossChecking>().DestroyCar(gameObject);
    }
}
