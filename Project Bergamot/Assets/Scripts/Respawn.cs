using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Respawn : MonoBehaviour
{
    Vector3 respawnPoint;
    bool enableRenderer;
    float flashTime = 30;

    private void Update()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint").transform.position;
    }

    public IEnumerator CarRespawn()
    {
        
        while (flashTime > 0)
        {
            transform.GetChild(0).rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;

            transform.GetChild(0).position = respawnPoint;
            Flash();
            yield return null;
        }
        yield return null;

        flashTime = 30;


        float angle = Camera.main.transform.eulerAngles.y * Mathf.PI / 90;
        Vector3 leadVel = CrossChecking.cars[0].carObject.transform.GetChild(0).GetComponent<Rigidbody>().velocity;
        transform.GetChild(0).GetComponent<Rigidbody>().velocity = leadVel;


        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
        GetComponent<Lives>().hasRespawned = true;
        yield return null;
    }


    void Flash()
    {
        flashTime -= Time.deltaTime*10;

        if (Mathf.RoundToInt(flashTime) % 2 == 0)
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = false;
        else
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
    }
}
