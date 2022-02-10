using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goes on parent gameobject (car)
public class Inventory : MonoBehaviour
{
    public Item item;

    public void UseItem()
    {
        if (item == null)
            return;

        item.Use(gameObject);
        item = null;
    }

    public void ItemCollect(Item newItem)
    {
        item = newItem;
        item.DisplayItem(gameObject);
    }

    public void UseNitro()
    {
        StartCoroutine(Boost());
    }

    public IEnumerator Boost()
    {
        GetComponent<CarMovmentNI>().speed = 3;
        yield return new WaitForSeconds(1);

        GetComponent<CarMovmentNI>().speed = 1;
    }
}
