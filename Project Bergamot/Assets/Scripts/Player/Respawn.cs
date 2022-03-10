using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Respawn : MonoBehaviour
{
    Vector3 respawnPoint;
    float flashTime = 60;
    Renderer[] wheelRenderers;
    int playerID;

    private void Awake()
    {
        playerID = GetComponent<PlayerDetails>().playerID-1;
        wheelRenderers = new Renderer[4];
        for (int i = 0; i < 4; i++)
            wheelRenderers[i] = transform.GetChild(0).GetChild(1).GetChild(i).GetChild(0).GetComponent<Renderer>();
    }

    private void Update()
    {
        if (GameObject.Find("point"+playerID) != null)
        respawnPoint = GameObject.Find("point" + playerID).transform.position;
    }

    public IEnumerator CarRespawn()
    {
        while (flashTime > 0)//Keeps the respawning car in the correct spot
        {
            
            transform.GetChild(0).rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;

            transform.GetChild(0).GetChild(0).GetComponent<Collider>().enabled = false;

            transform.GetChild(0).position = respawnPoint;
            Flash();
            yield return null;
        }
        yield return null;

        //set all values back to default
        flashTime = 60;

        Vector3 leadVel = GameObject.FindGameObjectWithTag("CrossChecking").GetComponent<CrossCheckHandler>().leadCar.transform.GetChild(0).GetComponent<Rigidbody>().velocity;
        transform.GetChild(0).GetComponent<Rigidbody>().velocity = leadVel;

        transform.GetChild(0).GetChild(0).GetComponent<Collider>().enabled = true;
        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
        foreach (Renderer renderer in wheelRenderers)
        {
            renderer.enabled = true;
        }
        GetComponent<Lives>().hasRespawned = true;
        Debug.Log("YES");

        yield return null;
    }


    void Flash()
    {
        flashTime -= Time.deltaTime*20;

        //if (Mathf.RoundToInt(flashTime) % 2 == 0)
        //{
        //    transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = false;
        //    foreach (Renderer renderer in wheelRenderers)
        //    {
        //        renderer.enabled = false;
        //    }
        //}

        //else
        //{
        //    transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
        //    foreach (Renderer renderer in wheelRenderers)
        //    {
        //        renderer.enabled = true;
        //    }
        //}
    }
}
