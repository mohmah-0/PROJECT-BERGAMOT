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
        Destroy(GetComponent<PlayerUI>().borderItem.transform.GetChild(0).gameObject);
    }

    public void ItemCollect(Item newItem)
    {
        if (item == null)
        {
            item = newItem;
            item.DisplayItem(RBGameObject);
            GetComponent<PlayerUI>().AddImage(newItem.Icon, GetComponent<PlayerUI>().borderItem.transform);
        }
    }

    public void UseNitro()
    {
        StartCoroutine(Boost());
    }

    public IEnumerator Boost()
    {
        GetComponent<CarMovment>().topSpeed = GetComponent<CarMovment>().topSpeed * 2;
        yield return new WaitForSeconds(1);

        GetComponent<CarMovment>().topSpeed = GetComponent<CarMovment>().topSpeed / 2;
    }
}
