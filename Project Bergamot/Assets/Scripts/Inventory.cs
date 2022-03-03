using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goes on parent gameobject (car)
public class Inventory : MonoBehaviour
{
    public Item item;
    [SerializeField] GameObject RBGameObject;

    public void UseItem()
    {
        if (item == null)
            return;

        item.Use(RBGameObject);
        item = null;
    }

    public void ItemCollect(Item newItem)
    {
        if (item == null)
        {
            item = newItem;
            item.DisplayItem(RBGameObject);
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
