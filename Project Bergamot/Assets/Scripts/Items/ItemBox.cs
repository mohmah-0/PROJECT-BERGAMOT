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

        Inventory inventory = other.transform.parent.parent.GetComponent<Inventory>();
        inventory.ItemCollect(items[Random.Range(0, items.Length)]);

        StartCoroutine("BoxDestroy");
    }

    IEnumerator BoxDestroy()
    {
        //Makes box inactive
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        lid.enabled = false;
        partSys.Play();
        FindObjectOfType<AudioManager>().Play("BoxOpen");

        yield return new WaitForSeconds(5f);
        //reactivates box
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        lid.enabled = true;
    }
}
