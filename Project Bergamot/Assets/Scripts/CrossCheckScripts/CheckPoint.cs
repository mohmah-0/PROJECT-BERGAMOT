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
        if(other.transform.parent.parent.tag == "Player")
        {
            transform.parent.GetComponent<CrossCheckHandler>().onCollide(id, other.transform.parent.parent.gameObject, goal);
        }
    }
}
