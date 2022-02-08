using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goes on parent gameobject (car)
public class Inventory : MonoBehaviour
{
    public Item item;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && item != null)
        {
            item.Use(gameObject);
            item = null;
        }
    }
    public void UseNitro()
    {
        StartCoroutine(Boost());
    }

    public IEnumerator Boost()
    {
        GetComponent<CarMovment>().speed = 3;
        yield return new WaitForSeconds(1);

        GetComponent<CarMovment>().speed = 1;
    }
}
