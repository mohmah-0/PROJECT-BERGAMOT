using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Item : MonoBehaviour
{
    public abstract void Use(GameObject car);
    public void DisplayItem(GameObject car)
    {
        GameObject item = Instantiate(gameObject, car.transform);
        item.GetComponent<Item>().StartCoroutine(DisplayAnim(item));
    }

    void Awake()
    {
        GetComponent<Animator>().enabled = false;
    }

    public IEnumerator DisplayAnim(GameObject item)
    {
        item.tag = "";
        item.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);
        item.GetComponent<Animator>().enabled = false;
        Destroy(item);
    }
}
