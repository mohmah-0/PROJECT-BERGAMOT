using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public ParticleSystem partSys;
    public Renderer lid;
    public Item[] items;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerHitbox"))
            return;
        Debug.Log("YES");

        Inventory inventory = other.transform.parent.parent.GetComponent<Inventory>();
        inventory.ItemCollect(items[Random.Range(0, items.Length)]);

        StartCoroutine("BoxDestroy");
    }

    IEnumerator BoxDestroy()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        lid.enabled = false;
        partSys.Play();

        yield return new WaitForSeconds(5f);
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        lid.enabled = true;
    }
}
