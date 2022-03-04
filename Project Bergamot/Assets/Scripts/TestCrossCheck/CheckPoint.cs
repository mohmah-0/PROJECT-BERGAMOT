using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private int id = 0;

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
        if(other.tag == "Player")
        {
            GetComponentInParent<CrossCheckHandler>().onCollide(id);
        }
    }
}
