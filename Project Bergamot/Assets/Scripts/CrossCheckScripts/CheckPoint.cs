using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private int id = 0;

    [SerializeField]
    public bool goal = false;


    public void setID(int id)
    {
        this.id = id;
    }

    public int getID()
    {
        return id;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Needs to get from the "body" part to the main car part. Body has the collider.
        Transform collidedCar = other.transform.parent.parent;
        if(collidedCar.tag == "Player")
        {
            transform.parent.GetComponent<CrossCheckHandler>().onCollide(id, collidedCar.gameObject, goal);
        }
    }
}
