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
        Debug.Log(other.name);
        if(other.transform.parent.parent.tag == "Player")
        {
            transform.parent.GetComponent<CrossCheckHandler>().onCollide(id, other.transform.parent.parent.gameObject);
        }
    }
}
